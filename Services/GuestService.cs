using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PokojeCore.Data;
using PokojeCore.Dtos;
using PokojeCore.Models;

namespace PokojeCore.Services
{
    public class GuestService(AppDbContext context, IMapper mapper) : IGuestService
    {
        public async Task<GuestResponse> AddGuestAsync(GuestRequest request)
        {
            var newGuest = mapper.Map<Guest>(request);
            newGuest.CreatedAt = DateTime.UtcNow; 
            context.Guests.Add(newGuest);

            await context.SaveChangesAsync();
            return mapper.Map<GuestResponse>(newGuest);
        }

        public async Task<bool> DeleteGuestAsync(int id)
        {
            var guestToDelete = await context.Guests.FindAsync(id);
            if (guestToDelete == null)
            {
                return false;
            }
            context.Guests.Remove(guestToDelete);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<GuestResponse> GetGuestByIdAsync(int id)
        {
            var guest = await context.Guests.Where(g => g.Id == id).
                        ProjectTo<GuestResponse>(mapper.ConfigurationProvider)
                        .FirstOrDefaultAsync();
            return guest;
        }

        public async Task<List<GuestResponse>> GetGuestsAsync()
        => await context.Guests.AsNoTracking()
            .ProjectTo<GuestResponse>(mapper.ConfigurationProvider)
            .ToListAsync();

        public async Task<bool> UpdateGuestAsync(int id, GuestRequest request)
        {
            var guestToUpdate = await context.Guests.FindAsync(id);
            if (guestToUpdate == null) {
                return false;
            }
            mapper.Map(request, guestToUpdate);
            guestToUpdate.UpdatedAt = DateTime.UtcNow;

            await context.SaveChangesAsync();
            return true;
        }
    }
}
