using PokojeCore.Data;
using Microsoft.EntityFrameworkCore;
using PokojeCore.Models;
using AutoMapper;
using PokojeCore.Dtos;
using AutoMapper.QueryableExtensions;

namespace PokojeCore.Services
{
    public class ReservationService(AppDbContext context, IMapper mapper) : IReservationService
    {
        public async Task<ReservationResponse> AddReservationAsync(ReservationRequest request)
        {
            var newReservation = mapper.Map<Reservation>(request);
            context.Reservations.Add( newReservation );
            await context.SaveChangesAsync();
            return mapper.Map<ReservationResponse>(newReservation);
        }

        public async Task<bool> DeleteReservationAsync(int id)
        {
            var reservationToDelete = await context.Reservations.FindAsync(id);
            if (reservationToDelete == null)
                return false;
            context.Reservations.Remove(reservationToDelete);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<ReservationResponse> GetReservationByIdAsync(int id)
        {
            var reservation = await context.Reservations.Where(r => r.Id == id).
                            ProjectTo<ReservationResponse>(mapper.ConfigurationProvider)
                            .FirstOrDefaultAsync();
            return reservation;

        }

        public async Task<List<ReservationResponse>> GetReservationsAsync()

            => await context.Reservations.AsNoTracking() //Faster queries and less memory usage
                    .ProjectTo<ReservationResponse>(mapper.ConfigurationProvider)
                    .ToListAsync();

        public async Task<bool> UpdateReservationAsync(int id, ReservationRequest request)
        {
            var existingReservation = await context.Reservations.FindAsync(id);
            if (existingReservation is null) return false;

            mapper.Map(request, existingReservation);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
