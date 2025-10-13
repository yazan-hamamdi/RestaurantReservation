using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.Domain.IServices
{
    public interface IReservationService : IBaseService<Reservation>
    {
        Task<List<Reservation>> GetReservationsByCustomerAsync(int customerId);
    }
}