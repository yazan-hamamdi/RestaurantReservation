using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.Db.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<List<Customer>> GetCustomersByPartySizeAsync(int minPartySize);
    }
}
