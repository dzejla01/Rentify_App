using System;
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
    public class ReviewService
        : BaseCRUDService<ReviewResponse, ReviewSearchObject, Review, ReviewUpsertRequest, ReviewUpsertRequest>,
          IReviewService
    {
        public ReviewService(RentifyDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

    }
}
