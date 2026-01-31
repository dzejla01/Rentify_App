namespace Rentify.Model.ResponseObjects
{
    public class ReservationResponse
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int PropertyId { get; set; }

        public bool IsMonthly { get; set; }

        public bool? IsApproved { get; set; }
    }
}
