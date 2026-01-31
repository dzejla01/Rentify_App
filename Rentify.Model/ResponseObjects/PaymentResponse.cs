using System;

namespace Rentify.Model.ResponseObjects
{
    public class PaymentResponse
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int PropertyId { get; set; }

        public double Price { get; set; }
        public bool IsPayed { get; set; }

        public DateTime? DateToPay { get; set; }
        public DateTime? WarningDateToPay { get; set; }
    }
}
