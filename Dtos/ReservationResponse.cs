namespace PokojeCore.Dtos
{
    public class ReservationResponse
    {
        public int Id { get; set; }

        public List<GuestShortResponse> Guests { get; set; } = new();

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public string Details { get; set; } = string.Empty;

        public string? VoucherId { get; set; }

        public string ContactPerson { get; set; } = string.Empty;
        public AccountShortResponse? Account { get; set; }

        public string Tasks { get; set; } = string.Empty;
        public AccountShortResponse? ModifiedBy { get; set; } // for demo it can be null

        public int? GroupReservationId { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
