using PokojeCore.Models;

namespace PokojeCore.Dtos
{
    public class ReservationRequest
    {
        public List<int> GuestIds { get; set; } = new();

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public string Details { get; set; } = string.Empty;

        public string? VoucherId { get; set; }

        public string ContactPerson { get; set; } = string.Empty;
        public int? AccountId { get; set; }

        public string Tasks { get; set; } = string.Empty;
        public int? ModifiedById { get; set; } // for demo it can be null

        public int? GroupReservationId { get; set; }
    }
}
