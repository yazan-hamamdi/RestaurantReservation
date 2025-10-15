using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Repositories
{
    public class OrderItemRepository : BaseRepository<OrderItem> , IOrderItemRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public OrderItemRepository(RestaurantReservationDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<bool> OrderExistsAsync(int orderId)
        {
            return await _context.Orders.AnyAsync(o => o.OrderId == orderId);
        }

        public async Task<bool> MenuItemExistsAsync(int menuItemId)
        {
            return await _context.MenuItems.AnyAsync(m => m.MenuItemId == menuItemId);
        }
    }
}
