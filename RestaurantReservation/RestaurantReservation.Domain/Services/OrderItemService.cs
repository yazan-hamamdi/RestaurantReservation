using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Domain.Exceptions;
using RestaurantReservation.Domain.IServices;

namespace RestaurantReservation.Domain.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly RestaurantReservationDbContext _context;

        public OrderItemService(IOrderItemRepository repository, RestaurantReservationDbContext context)
        {
            _orderItemRepository = repository;
            _context = context;
        }

        public async Task<List<OrderItem>> GetAllAsync() =>
            await _orderItemRepository.GetAllAsync();

        public async Task<OrderItem> GetByIdAsync(int id)
        {
            var item = await _orderItemRepository.GetByIdAsync(id);
            if (item == null)
                throw new EntityNotFoundException($"Order item with ID {id} not found");

            return item;
        }

        public async Task AddAsync(OrderItem orderItem)
        {
            if (orderItem == null)
                throw new ArgumentNullException(nameof(orderItem));

            if (!await _orderItemRepository.OrderExistsAsync(orderItem.OrderId))
                throw new EntityNotFoundException($"Order with ID {orderItem.OrderId} not found");

            if (!await _orderItemRepository.MenuItemExistsAsync(orderItem.ItemId))
                throw new EntityNotFoundException($"Menu item with ID {orderItem.ItemId} not found");

            await _orderItemRepository.AddAsync(orderItem);
        }

        public async Task UpdateAsync(OrderItem orderItem)
        {
            if (orderItem == null)
                throw new ArgumentNullException(nameof(orderItem));

            var existing = await _orderItemRepository.GetByIdAsync(orderItem.OrderItemId);
            if (existing == null)
                throw new EntityNotFoundException($"Cannot update — Order item with ID {orderItem.OrderItemId} not found");

            await _orderItemRepository.UpdateAsync(orderItem);
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _orderItemRepository.GetByIdAsync(id);
            if (existing == null)
                throw new EntityNotFoundException($"Cannot delete — Order item with ID {id} not found");

            await _orderItemRepository.DeleteAsync(id);
        }
    }
}
