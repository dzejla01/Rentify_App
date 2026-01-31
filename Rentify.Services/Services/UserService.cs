// Rentify.Services/Implementation/UserService.cs
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Rentify.Model.RequestObjects;
using Rentify.Model.ResponseObject;
using Rentify.Model.ResponseObjects;
using Rentify.Model.SearchObjects;
using Rentify.Services.Database;
using Rentify.Services.Helpers;
using Rentify.Services.Interfaces;
using Rentify.Services.Services;
using System;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Rentify.Services
{
    public class UserService
        : BaseCRUDService<UserResponse, UserSearchObject, User, UserInsertRequest, UserUpdateRequest>,
          IUserService
    {
        private readonly IConfiguration _configuration;
        public UserService(RentifyDbContext context, IConfiguration configuration,IMapper mapper) : base(context, mapper)
        {
            _configuration = configuration;
        }


        protected override IQueryable<User> ApplyFilter(IQueryable<User> query, UserSearchObject search)
        {
            if (!string.IsNullOrWhiteSpace(search.NameFTS))
            {
                var s = search.NameFTS.Trim().ToLower();
                query = query.Where(x =>
                    x.FirstName.ToLower().Contains(s) ||
                    x.LastName.ToLower().Contains(s) ||
                    x.Username.ToLower().Contains(s) ||
                    x.Email.ToLower().Contains(s));
            }

            if (search.IsActive.HasValue)
                query = query.Where(x => x.IsActive == search.IsActive.Value);

            if (search.IsVlasnik.HasValue)
                query = query.Where(x => x.IsVlasnik == search.IsVlasnik.Value);

            return query;
        }

        protected override User MapInsertToEntity(User entity, UserInsertRequest request)
        {
            _mapper.Map(request, entity);

            // Password
            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                UserHelper.CreatePasswordHash(request.Password, out var hash, out var salt);
                entity.PasswordHash = hash;
                entity.PasswordSalt = salt;
            }

            entity.CreatedAt = DateTime.UtcNow;
            return entity;
        }

        protected override void MapUpdateToEntity(User entity, UserUpdateRequest request)
        {
            // Ne diramo CreatedAt
            var createdAt = entity.CreatedAt;

            _mapper.Map(request, entity);

            entity.CreatedAt = createdAt;

            // Ako je password poslan, mijenjamo hash/salt, inače ostaje isto
            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                UserHelper.CreatePasswordHash(request.Password, out var hash, out var salt);
                entity.PasswordHash = hash;
                entity.PasswordSalt = salt;
            }
        }

        protected override async Task BeforeInsert(User entity, UserInsertRequest request)
        {
            // Unique checks (Username/Email)
            var exists = await _context.Users.AnyAsync(x =>
                x.Username == entity.Username || x.Email == entity.Email);

            if (exists)
                throw new InvalidOperationException("Korisnik sa istim username/email već postoji.");

            await UserHelper.AssignRoleByIsVlasnikAsync(entity, request);
        }

        protected override async Task BeforeUpdate(User entity, UserUpdateRequest request)
        {
            // Unique checks (Username/Email) - ignorisi trenutnog usera
            var exists = await _context.Users.AnyAsync(x =>
                x.Id != entity.Id && (x.Username == request.Username || x.Email == request.Email));

            if (exists)
                throw new InvalidOperationException("Korisnik sa istim username/email već postoji.");
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var user = await _context.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(x => x.Username == request.Username);

            if (user == null || !user.IsActive)
                throw new UnauthorizedAccessException("Pogrešan username ili password.");

            if (!UserHelper.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt))
                throw new UnauthorizedAccessException("Pogrešan username ili password.");

            var token = UserHelper.CreateJwt(user, _configuration);

            var response = new LoginResponse
            {
                UserId = user.Id,
                UserName = request.Username,
                Token = token,
                Roles = user.UserRoles
                    .Select(ur => ur.Role.Name)
                    .ToList()
            };

            user.LastLoginAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return response;
        }




    }
}
