using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Domain.IServices;

namespace RestaurantReservation.Domain.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Order>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Order?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task AddAsync(Order order) => await _repository.AddAsync(order);
        public async Task UpdateAsync(Order order) => await _repository.UpdateAsync(order);
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}
