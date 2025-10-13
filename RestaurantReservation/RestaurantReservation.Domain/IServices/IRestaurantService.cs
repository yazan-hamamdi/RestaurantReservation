using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.Domain.IServices
{
    public interface IRestaurantService : IBaseService<Restaurant>
    {
        Task<decimal> CalculateTotalRevenueAsync(int restaurantId);
    }
}
