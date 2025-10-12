using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Repositories
{
    public class OrderRepository : BaseRepository<Order> , IOrderRepository
    {
        public OrderRepository(RestaurantReservationDbContext context) : base(context) { }
    }
}
