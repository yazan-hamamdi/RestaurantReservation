using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Domain.Exceptions;
using RestaurantReservation.Domain.IServices;

namespace RestaurantReservation.Domain.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository repository)
        {
            _orderRepository = repository;
        }

        public async Task<List<Order>> GetAllAsync() => await _orderRepository.GetAllAsync();

        public async Task<Order> GetByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
                throw new EntityNotFoundException($"Order with ID {id} not found");

            return order;
        }

        public async Task AddAsync(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            if (!await _orderRepository.ReservationExistsAsync(order.ReservationId))
                throw new EntityNotFoundException($"Reservation with ID {order.ReservationId} not found");

            if (!await _orderRepository.EmployeeExistsAsync(order.EmployeeId))
                throw new EntityNotFoundException($"Employee with ID {order.EmployeeId} not found");

            await _orderRepository.AddAsync(order);
        }

        public async Task UpdateAsync(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            var existing = await _orderRepository.GetByIdAsync(order.OrderId);
            if (existing == null)
                throw new EntityNotFoundException($"Order with ID {order.OrderId} not found");

            await _orderRepository.UpdateAsync(order);
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _orderRepository.GetByIdAsync(id);
            if (existing == null)
                throw new EntityNotFoundException($"Order with ID {id} not found");

            await _orderRepository.DeleteAsync(id);
        }

        public async Task<List<Order>> ListOrdersAndMenuItemsAsync(int reservationId)
        {
            if (!await _orderRepository.ReservationExistsAsync(reservationId))
                throw new EntityNotFoundException($"Reservation with ID {reservationId} not found");

            return await _orderRepository.ListOrdersAndMenuItemsAsync(reservationId);
        }

        public async Task<decimal> CalculateAverageOrderAmountAsync(int employeeId)
        {
            if (!await _orderRepository.EmployeeExistsAsync(employeeId))
                throw new EntityNotFoundException($"Employee with ID {employeeId} not found");

            return await _orderRepository.CalculateAverageOrderAmountAsync(employeeId);
        }
    }
}
