using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Repositories
{
    public class CustomerRepository : BaseRepository<Customer> , ICustomerRepository
    {
        public CustomerRepository(RestaurantReservationDbContext context) : base(context) { }
    }
}
