using Microsoft.EntityFrameworkCore;
using PokojeCore.Models;

namespace PokojeCore.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Reservation> Reservations => Set<Reservation>();
    }
}
