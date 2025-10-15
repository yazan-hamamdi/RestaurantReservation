using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.ViewDTOs;

namespace RestaurantReservation.Db.Interfaces
{
    public interface IReservationRepository : IBaseRepository<Reservation>
    {
        Task<bool> CustomerExistsAsync(int customerId);
        Task<bool> RestaurantExistsAsync(int restaurantId);
        Task<bool> TableExistsAsync(int tableId);

        Task<List<Reservation>> GetReservationsByCustomerAsync(int customerId);
        Task<List<ReservationView>> GetReservationsWithCustomerRestaurantAsync();
    }
}
