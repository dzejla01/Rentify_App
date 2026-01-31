using System.Linq;
using Microsoft.EntityFrameworkCore;
using MapsterMapper;
using Rentify.Model.SearchObjects;
using Rentify.Model.RequestObjects;
using Rentify.Model.ResponseObjects;
using Rentify.Services.Database;
using Rentify.Services.Interfaces;

namespace Rentify.Services.Services
{
    public class AppointmentService
        : BaseCRUDService<AppointmentResponse, AppointmentSearchObject, Appointment, AppointmentUpsertRequest, AppointmentUpsertRequest>,
          IAppointmentService
    {
        public AppointmentService(RentifyDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
        
        protected override IQueryable<Appointment> ApplyFilter(IQueryable<Appointment> query, AppointmentSearchObject search)
        {
            query = base.ApplyFilter(query, search);

            if (search.UserId.HasValue)
                query = query.Where(x => x.UserId == search.UserId.Value);

            if (search.PropertyId.HasValue)
                query = query.Where(x => x.PropertyId == search.PropertyId.Value);

            if (search.IsApproved.HasValue)
                query = query.Where(x => x.IsApproved == search.IsApproved.Value);

            if (search.DateFrom.HasValue)
                query = query.Where(x => x.DateAppointment >= search.DateFrom.Value);

            if (search.DateTo.HasValue)
                query = query.Where(x => x.DateAppointment <= search.DateTo.Value);

            return query;
        }
    }
}
