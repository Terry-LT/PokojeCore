using PokojeCore.Dtos;

namespace PokojeCore.Services
{
    public interface IReservationService
    {
        Task<List<ReservationResponse>> GetReservationsAsync();
        Task<ReservationResponse> GetReservationByIdAsync(int id);
        Task<ReservationResponse> AddReservationAsync(ReservationRequest request);
        Task<bool> UpdateReservationAsync(int id, ReservationRequest request);
        Task<bool> DeleteReservationAsync(int id);
    }
}
