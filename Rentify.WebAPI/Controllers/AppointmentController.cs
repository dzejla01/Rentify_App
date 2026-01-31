using Microsoft.AspNetCore.Mvc;
using Rentify.Model.RequestObjects;
using Rentify.Model.ResponseObjects;
using Rentify.Model.SearchObjects;
using Rentify.Services.Interfaces;

namespace Rentify.WebAPI.Controllers
{
    
    public class AppointmentController
        : BaseCRUDController<AppointmentResponse, AppointmentSearchObject, AppointmentUpsertRequest, AppointmentUpsertRequest>
    {
        public AppointmentController(IAppointmentService service) : base(service)
        {
        }
    }
}
