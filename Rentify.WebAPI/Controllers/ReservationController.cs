using Microsoft.AspNetCore.Mvc;
using Rentify.Model.RequestObjects;
using Rentify.Model.ResponseObjects;
using Rentify.Model.SearchObjects;
using Rentify.Services.Interfaces;

namespace Rentify.WebAPI.Controllers
{

    public class ReservationController
        : BaseCRUDController<ReservationResponse, ReservationSearchObject, ReservationUpsertRequest, ReservationUpsertRequest>
    {
        public ReservationController(IReservationService service) : base(service)
        {
        }
    }
}
