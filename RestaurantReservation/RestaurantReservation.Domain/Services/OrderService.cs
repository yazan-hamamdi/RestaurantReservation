using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;
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
        public async Task<Order?> GetByIdAsync(int id) => await _orderRepository.GetByIdAsync(id);
        public async Task AddAsync(Order order) => await _orderRepository.AddAsync(order);
        public async Task UpdateAsync(Order order) => await _orderRepository.UpdateAsync(order);
        public async Task DeleteAsync(int id) => await _orderRepository.DeleteAsync(id);

        public async Task<List<Order>> ListOrdersAndMenuItemsAsync(int reservationId)
        {
            var orders = await _context.Orders
                .Where(o => o.ReservationId == reservationId)
                .Include(o => o.OrderItems)       
                    .ThenInclude(oi => oi.MenuItem)
                .ToListAsync();

            return orders;
        }

        public async Task<decimal> CalculateAverageOrderAmountAsync(int employeeId)
        {
            var average = await _context.Orders
                .Where(o => o.EmployeeId == employeeId)   
                .Select(o => o.TotalAmount)
                .DefaultIfEmpty(0)         
                .AverageAsync(); 

            return average;
        }
    }
}
