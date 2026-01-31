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
    public class PaymentService
        : BaseCRUDService<PaymentResponse, PaymentSearchObject, Payment, PaymentUpsertRequest, PaymentUpsertRequest>,
          IPaymentService
    {
        public PaymentService(RentifyDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
