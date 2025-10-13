using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.Db.Interfaces
{
    public interface IRestaurantRepository : IBaseRepository<Restaurant>
    {
        Task<decimal> CalculateTotalRevenueAsync(int restaurantId);
    }
}
