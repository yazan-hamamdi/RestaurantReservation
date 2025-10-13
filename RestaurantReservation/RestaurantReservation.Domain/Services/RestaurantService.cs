using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Domain.Exceptions;
using RestaurantReservation.Domain.IServices;

namespace RestaurantReservation.Domain.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly RestaurantReservationDbContext _context;

        public RestaurantService(IRestaurantRepository repository, RestaurantReservationDbContext context)
        {
            _restaurantRepository = repository;
            _context = context;
        }

        public async Task<List<Restaurant>> GetAllAsync() =>
            await _restaurantRepository.GetAllAsync();

        public async Task<Restaurant> GetByIdAsync(int id)
        {
            var restaurant = await _restaurantRepository.GetByIdAsync(id);
            if (restaurant == null)
                throw new EntityNotFoundException($"Restaurant with ID {id} not found.");

            return restaurant;
        }

        public async Task AddAsync(Restaurant restaurant)
        {
            if (restaurant == null)
                throw new ArgumentNullException(nameof(restaurant));

            await _restaurantRepository.AddAsync(restaurant);
        }

        public async Task UpdateAsync(Restaurant restaurant)
        {
            if (restaurant == null)
                throw new ArgumentNullException(nameof(restaurant));

            var existing = await _restaurantRepository.GetByIdAsync(restaurant.RestaurantId);
            if (existing == null)
                throw new EntityNotFoundException($"Restaurant with ID {restaurant.RestaurantId} not found.");

            await _restaurantRepository.UpdateAsync(restaurant);
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _restaurantRepository.GetByIdAsync(id);
            if (existing == null)
                throw new EntityNotFoundException($"Restaurant with ID {id} not found.");

            await _restaurantRepository.DeleteAsync(id);
        }

        public async Task<decimal> CalculateTotalRevenueAsync(int restaurantId)
        {
            var exists = await _context.Restaurants.AnyAsync(r => r.RestaurantId == restaurantId);
            if (!exists)
                throw new EntityNotFoundException($"Restaurant with ID {restaurantId} not found.");

            var total = await _restaurantRepository.CalculateTotalRevenueAsync(restaurantId);
            return total;
        }
    }
}
