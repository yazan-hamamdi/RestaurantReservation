using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Db.ViewDTOs;

namespace RestaurantReservation.Db.Repositories
{
    public class ReservationRepository : BaseRepository<Reservation> , IReservationRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public ReservationRepository(RestaurantReservationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Reservation>> GetReservationsByCustomerAsync(int customerId)
        {
            return await _context.Reservations
                .Where(r => r.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<List<ReservationView>> GetReservationsWithCustomerRestaurantAsync()
        {
            return await _context.ReservationViews
                .OrderBy(r => r.ReservationDate)
                .ToListAsync();
        }
    }
}
