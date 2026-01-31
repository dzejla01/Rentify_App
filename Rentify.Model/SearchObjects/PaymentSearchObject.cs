using System;
using Rentify.Model.SearchObjects;

namespace Rentify.Model.SearchObjects
{
    public class PaymentSearchObject : BaseSearchObject
    {
        public int? UserId { get; set; }
        public int? PropertyId { get; set; }
        public bool? IsPayed { get; set; }

        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }

        public DateTime? DateToPayFrom { get; set; }
        public DateTime? DateToPayTo { get; set; }
    }
}
