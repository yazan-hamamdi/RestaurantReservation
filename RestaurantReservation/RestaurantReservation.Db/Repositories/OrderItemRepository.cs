using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Repositories
{
    public class OrderItemRepository : BaseRepository<OrderItem> , IOrderItemRepository
    {
        public OrderItemRepository(RestaurantReservationDbContext context) : base(context) { }
    }
}
