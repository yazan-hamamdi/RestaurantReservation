using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.ViewDTOs;

namespace RestaurantReservation.Domain.IServices
{
    public interface IReservationService : IBaseService<Reservation>
    {
        Task<List<Reservation>> GetReservationsByCustomerAsync(int customerId);
        Task<List<ReservationView>> GetReservationsWithCustomerRestaurantAsync();
    }
}