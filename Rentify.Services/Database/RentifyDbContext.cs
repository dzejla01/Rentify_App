using Microsoft.EntityFrameworkCore;
using Rentify.Services.Database;

public class RentifyDbContext : DbContext
{
    public RentifyDbContext(DbContextOptions<RentifyDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserRole>()
            .HasKey(x => new { x.UserId, x.RoleId });

        SeedData.Seed(modelBuilder);

    }
}
