using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Domain.IServices;

namespace RestaurantReservation.Domain.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _repository;

        public MenuItemService(IMenuItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<MenuItem>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<MenuItem?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task AddAsync(MenuItem item) => await _repository.AddAsync(item);
        public async Task UpdateAsync(MenuItem item) => await _repository.UpdateAsync(item);
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}
