using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Domain.IServices;

namespace RestaurantReservation.Domain.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemService(IOrderItemRepository repository)
        {
            _orderItemRepository = repository;
        }

        public async Task<List<OrderItem>> GetAllAsync() => await _orderItemRepository.GetAllAsync();
        public async Task<OrderItem?> GetByIdAsync(int id) => await _orderItemRepository.GetByIdAsync(id);
        public async Task AddAsync(OrderItem orderItem) => await _orderItemRepository.AddAsync(orderItem);
        public async Task UpdateAsync(OrderItem orderItem) => await _orderItemRepository.UpdateAsync(orderItem);
        public async Task DeleteAsync(int id) => await _orderItemRepository.DeleteAsync(id);
    }
}
