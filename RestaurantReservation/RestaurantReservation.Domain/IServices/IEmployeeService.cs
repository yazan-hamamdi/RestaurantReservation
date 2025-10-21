using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.ViewDTOs;

namespace RestaurantReservation.Domain.IServices
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        Task<List<Employee>> ListManagersAsync();
        Task<List<EmployeeView>> GetEmployeesWithRestaurantAsync();
    }
}
