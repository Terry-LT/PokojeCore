
namespace PokojeCore.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public List<Guest> Guests { get; set; } = new();
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Details { get; set; } = string.Empty;

        public string? VoucherId { get; set; } 
        public string ContactPerson { get; set; } = string.Empty;

        //Can be null, as it’s standard practice to delete receptions when they no longer work here.
        public Account? CreatedBy {  get; set; } 
        public string Tasks { get; set; } = string.Empty; //for demo
        public Account? ModifiedBy { get; set; }
        public int? GroupReservationId { get; set; } //for demo

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
