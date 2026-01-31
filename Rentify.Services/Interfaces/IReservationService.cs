using Rentify.Model.RequestObjects;
using Rentify.Model.ResponseObjects;
using Rentify.Model.SearchObjects;

namespace Rentify.Services.Interfaces
{
    public interface IReservationService
        : ICRUDService<ReservationResponse, ReservationSearchObject, ReservationUpsertRequest, ReservationUpsertRequest>
    {
    }
}
