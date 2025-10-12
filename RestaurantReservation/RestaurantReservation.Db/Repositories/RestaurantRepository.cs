using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Repositories
{
    public class RestaurantRepository : BaseRepository<Restaurant> , IRestaurantRepository
    {
        public RestaurantRepository(RestaurantReservationDbContext context)
            : base(context)
        {
        }
    }
}