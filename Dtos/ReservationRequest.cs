namespace PokojeCore.Dtos
{
    public class ReservationRequest
    {
        public string Guests { get; set; } = string.Empty;
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Details { get; set; } = string.Empty;

        public int ReservationId { get; set; }
        public string ContactPerson { get; set; } = string.Empty;
        public int Account { get; set; }
        public string Tasks { get; set; } = string.Empty;
        public string ModifiedBy { get; set; } = string.Empty;
        public int? GroupReservationId { get; set; }
    }
}
