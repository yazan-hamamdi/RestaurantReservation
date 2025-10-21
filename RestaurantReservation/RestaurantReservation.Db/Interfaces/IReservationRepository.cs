using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.ViewDTOs;

namespace RestaurantReservation.Db.Interfaces
{
    public interface IReservationRepository : IBaseRepository<Reservation>
    {
        Task<List<Reservation>> GetReservationsByCustomerAsync(int customerId);
        Task<List<ReservationView>> GetReservationsWithCustomerRestaurantAsync();
    }
}
