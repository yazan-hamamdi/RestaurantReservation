using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Domain.IServices;

namespace RestaurantReservation.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Customer>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Customer?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task AddAsync(Customer customer) => await _repository.AddAsync(customer);
        public async Task UpdateAsync(Customer customer) => await _repository.UpdateAsync(customer);
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}
