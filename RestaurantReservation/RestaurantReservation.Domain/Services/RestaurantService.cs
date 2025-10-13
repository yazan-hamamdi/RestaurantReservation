using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Domain.IServices;

namespace RestaurantReservation.Domain.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _repository;

        public RestaurantService(IRestaurantRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Restaurant>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Restaurant?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task AddAsync(Restaurant restaurant) => await _repository.AddAsync(restaurant);
        public async Task UpdateAsync(Restaurant restaurant) => await _repository.UpdateAsync(restaurant);
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}
