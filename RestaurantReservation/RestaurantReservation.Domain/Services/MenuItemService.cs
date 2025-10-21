using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Domain.Exceptions;
using RestaurantReservation.Domain.IServices;

namespace RestaurantReservation.Domain.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public MenuItemService(IMenuItemRepository repository)
        {
            _menuItemRepository = repository;
        }

        public async Task<List<MenuItem>> GetAllAsync() =>
            await _menuItemRepository.GetAllAsync();

        public async Task<MenuItem> GetByIdAsync(int id)
        {
            var item = await _menuItemRepository.GetByIdAsync(id);
            if (item == null)
                throw new EntityNotFoundException($"Menu item with ID {id} not found");

            return item;
        }

        public async Task AddAsync(MenuItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            await _menuItemRepository.AddAsync(item);
        }

        public async Task UpdateAsync(MenuItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            var existing = await _menuItemRepository.GetByIdAsync(item.MenuItemId);
            if (existing == null)
                throw new EntityNotFoundException($"Cannot update — Menu item with ID {item.MenuItemId} not found");

            await _menuItemRepository.UpdateAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _menuItemRepository.GetByIdAsync(id);
            if (existing == null)
                throw new EntityNotFoundException($"Cannot delete — Menu item with ID {id} not found");

            await _menuItemRepository.DeleteAsync(id);
        }

        public async Task<List<MenuItem>> ListOrderedMenuItemsAsync(int reservationId)
        {
            return await _menuItemRepository.ListOrderedMenuItemsAsync(reservationId);
        }
    }
}
