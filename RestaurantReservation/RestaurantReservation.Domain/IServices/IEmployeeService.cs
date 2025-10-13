using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.Domain.IServices
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        Task<List<Employee>> ListManagersAsync();
    }
}
