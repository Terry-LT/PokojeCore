using PokojeCore.Data;
using PokojeCore.Dtos;
using Microsoft.EntityFrameworkCore;
using PokojeCore.Models;
using AutoMapper;

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
                            Select(
                            r => new ReservationResponse
                            {
                                Id = r.Id,
                                Guests = r.Guests,
                                CheckInDate = r.CheckInDate,
                                CheckOutDate = r.CheckOutDate,
                                Details = r.Details,
                                VoucherId = r.VoucherId,
                                ContactPerson = r.ContactPerson,
                                Account = r.Account,
                                Tasks = r.Tasks,
                                ModifiedBy = r.ModifiedBy,
                                GroupReservationId = r.GroupReservationId

                            }
                            ).FirstOrDefaultAsync();
            return reservation;

        }

        public async Task<List<ReservationResponse>> GetReservationsAsync()
            => await context.Reservations.AsNoTracking() //Faster queries and less memory usage
                    .Select(r => new ReservationResponse
                    {
                        Id = r.Id,
                        Guests = r.Guests,
                        CheckInDate = r.CheckInDate,
                        CheckOutDate = r.CheckOutDate,
                        Details = r.Details,
                        VoucherId = r.VoucherId,
                        ContactPerson = r.ContactPerson,
                        Account = r.Account,
                        Tasks = r.Tasks,
                        ModifiedBy = r.ModifiedBy,
                        GroupReservationId = r.GroupReservationId
                    })
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
