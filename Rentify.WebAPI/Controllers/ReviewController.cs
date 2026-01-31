using Microsoft.AspNetCore.Mvc;
using Rentify.Model.RequestObjects;
using Rentify.Model.ResponseObjects;
using Rentify.Model.SearchObjects;
using Rentify.Services.Interfaces;

namespace Rentify.WebAPI.Controllers
{
    
    public class ReviewController
        : BaseCRUDController<ReviewResponse, ReviewSearchObject, ReviewUpsertRequest, ReviewUpsertRequest>
    {
        public ReviewController(IReviewService service) : base(service)
        {
        }
    }
}
