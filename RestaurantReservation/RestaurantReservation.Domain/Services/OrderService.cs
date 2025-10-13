using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Domain.Exceptions;
using RestaurantReservation.Domain.IServices;

namespace RestaurantReservation.Domain.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly RestaurantReservationDbContext _context;

        public OrderService(IOrderRepository repository, RestaurantReservationDbContext context)
        {
            _orderRepository = repository;
            _context = context;
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

            var reservationExists = await _context.Reservations.AnyAsync(r => r.ReservationId == order.ReservationId);
            if (!reservationExists)
                throw new EntityNotFoundException($"Reservation with ID {order.ReservationId} not found");

            var employeeExists = await _context.Employees.AnyAsync(e => e.EmployeeId == order.EmployeeId);
            if (!employeeExists)
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
            var exists = await _context.Reservations.AnyAsync(r => r.ReservationId == reservationId);
            if (!exists)
                throw new EntityNotFoundException($"Reservation with ID {reservationId} not found");

            var orders = await _context.Orders
                .Where(o => o.ReservationId == reservationId)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.MenuItem)
                .ToListAsync();

            return orders;
        }

        public async Task<decimal> CalculateAverageOrderAmountAsync(int employeeId)
        {
            var employeeExists = await _context.Employees.AnyAsync(e => e.EmployeeId == employeeId);
            if (!employeeExists)
                throw new EntityNotFoundException($"Employee with ID {employeeId} not found");

            var hasOrders = await _context.Orders.AnyAsync(o => o.EmployeeId == employeeId);
            if (!hasOrders)
                return 0m;

            var average = await _context.Orders
                .Where(o => o.EmployeeId == employeeId)
                .Select(o => o.TotalAmount)
                .AverageAsync();

            return average;
        }
    }
}
