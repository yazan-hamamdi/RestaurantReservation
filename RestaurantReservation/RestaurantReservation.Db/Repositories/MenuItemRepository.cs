using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Repositories
{
    public class MenuItemRepository : BaseRepository<MenuItem> , IMenuItemRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public MenuItemRepository(RestaurantReservationDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<MenuItem>> ListOrderedMenuItemsAsync(int reservationId)
        {
            var menuItems = await _context.OrderItems
                .Where(oi => oi.Order.ReservationId == reservationId)
                .Include(oi => oi.MenuItem)
                .Select(oi => oi.MenuItem)
                .Distinct()
                .ToListAsync();

            return menuItems;
        }
    }
}
