
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
        public int Account {  get; set; } //for demo
        public string Tasks { get; set; } = string.Empty; //for demo
        public string ModifiedBy { get; set; } = string.Empty; //for demo
        public int? GroupReservationId { get; set; } //for demo

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
