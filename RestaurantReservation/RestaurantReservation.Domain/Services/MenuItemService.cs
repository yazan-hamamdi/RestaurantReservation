using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Domain.IServices;

namespace RestaurantReservation.Domain.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly RestaurantReservationDbContext _context;

        public MenuItemService(IMenuItemRepository repository, RestaurantReservationDbContext context)
        {
            _menuItemRepository = repository;
            _context = context;
        }

        public async Task<List<MenuItem>> GetAllAsync() => await _menuItemRepository.GetAllAsync();
        public async Task<MenuItem?> GetByIdAsync(int id) => await _menuItemRepository.GetByIdAsync(id);
        public async Task AddAsync(MenuItem item) => await _menuItemRepository.AddAsync(item);
        public async Task UpdateAsync(MenuItem item) => await _menuItemRepository.UpdateAsync(item);
        public async Task DeleteAsync(int id) => await _menuItemRepository.DeleteAsync(id);

        public async Task<List<MenuItem>> ListOrderedMenuItemsAsync(int reservationId)
        {
            var menuItems = await _context.OrderItems
                .Where(oi => oi.Order.ReservationId == reservationId) 
                .Include(oi => oi.MenuItem)                          
                .Select(oi => oi.MenuItem)                           
                .Distinct()                
                .ToListAsync();

            return menuItems;
        }

    }
}
