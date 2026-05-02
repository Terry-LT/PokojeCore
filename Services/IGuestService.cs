using PokojeCore.Dtos;

namespace PokojeCore.Services
{
    public interface IGuestService
    {
        Task<List<GuestResponse>> GetGuestsAsync();
        Task<GuestResponse> GetGuestByIdAsync(int id);
        Task<GuestResponse> AddGuestAsync(GuestRequest request);
        Task<bool> UpdateGuestAsync(int id, GuestRequest request);
        Task<bool> DeleteGuestAsync(int id);

    }
}
