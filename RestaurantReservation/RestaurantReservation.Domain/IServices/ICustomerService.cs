using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.Domain.IServices
{
    public interface ICustomerService : IBaseService<Customer>
    {
        Task<List<Customer>> GetCustomersByPartySizeAsync(int minPartySize);
    }
}
