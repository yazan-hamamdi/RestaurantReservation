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

        public async Task<bool> CustomerExistsAsync(int customerId)
        {
            return await _context.Customers.AnyAsync(c => c.CustomerId == customerId);
        }

        public async Task<bool> RestaurantExistsAsync(int restaurantId)
        {
            return await _context.Restaurants.AnyAsync(r => r.RestaurantId == restaurantId);
        }

        public async Task<bool> TableExistsAsync(int tableId)
        {
            return await _context.Tables.AnyAsync(t => t.TableId == tableId);
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
