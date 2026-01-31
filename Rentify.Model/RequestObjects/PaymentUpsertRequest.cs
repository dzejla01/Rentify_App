using System;
using System.ComponentModel.DataAnnotations;

namespace Rentify.Model.RequestObjects
{
    public class PaymentUpsertRequest
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int PropertyId { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        public bool IsPayed { get; set; }

        public DateTime? DateToPay { get; set; }
        public DateTime? WarningDateToPay { get; set; }
    }
}
