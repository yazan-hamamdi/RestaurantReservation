using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.ViewDTOs;

namespace RestaurantReservation.Db.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task<List<Employee>> ListManagersAsync();
        Task<List<EmployeeView>> GetEmployeesWithRestaurantAsync();
    }
}
