using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Repositories
{
    public class OrderRepository : BaseRepository<Order> , IOrderRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public OrderRepository(RestaurantReservationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ReservationExistsAsync(int reservationId)
        {
            return await _context.Reservations.AnyAsync(r => r.ReservationId == reservationId);
        }

        public async Task<bool> EmployeeExistsAsync(int employeeId)
        {
            return await _context.Employees.AnyAsync(e => e.EmployeeId == employeeId);
        }

        public async Task<List<Order>> ListOrdersAndMenuItemsAsync(int reservationId)
        {
            return await _context.Orders
                .Where(o => o.ReservationId == reservationId)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.MenuItem)
                .ToListAsync();
        }

        public async Task<decimal> CalculateAverageOrderAmountAsync(int employeeId)
        {
            return await _context.Orders
                .Where(o => o.EmployeeId == employeeId)
                .Select(o => (decimal?)o.TotalAmount)
                .AverageAsync() ?? 0m; 
        }
    }
}
