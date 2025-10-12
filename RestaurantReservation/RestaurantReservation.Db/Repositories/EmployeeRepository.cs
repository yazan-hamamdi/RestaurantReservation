using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee> , IEmployeeRepository
    {
        public EmployeeRepository(RestaurantReservationDbContext context) : base(context) { }
    }
}
