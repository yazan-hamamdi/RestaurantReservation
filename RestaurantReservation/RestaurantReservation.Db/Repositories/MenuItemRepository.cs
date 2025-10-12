using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Repositories
{
    public class MenuItemRepository : BaseRepository<MenuItem> , IMenuItemRepository
    {
        public MenuItemRepository(RestaurantReservationDbContext context) : base(context) { }
    }
}
