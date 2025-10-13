using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Domain.IServices;

namespace RestaurantReservation.Domain.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository repository)
        {
            _restaurantRepository = repository;
        }

        public async Task<List<Restaurant>> GetAllAsync() => await _restaurantRepository.GetAllAsync();
        public async Task<Restaurant?> GetByIdAsync(int id) => await _restaurantRepository.GetByIdAsync(id);
        public async Task AddAsync(Restaurant restaurant) => await _restaurantRepository.AddAsync(restaurant);
        public async Task UpdateAsync(Restaurant restaurant) => await _restaurantRepository.UpdateAsync(restaurant);
        public async Task DeleteAsync(int id) => await _restaurantRepository.DeleteAsync(id);

        public async Task<decimal> CalculateTotalRevenueAsync(int restaurantId)
        {
            return await _restaurantRepository.CalculateTotalRevenueAsync(restaurantId);
        }

    }
}
