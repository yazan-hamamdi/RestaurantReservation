using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Domain.IServices;

namespace RestaurantReservation.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository repository)
        {
            _customerRepository = repository;
        }

        public async Task<List<Customer>> GetAllAsync() => await _customerRepository.GetAllAsync();
        public async Task<Customer?> GetByIdAsync(int id) => await _customerRepository.GetByIdAsync(id);
        public async Task AddAsync(Customer customer) => await _customerRepository.AddAsync(customer);
        public async Task UpdateAsync(Customer customer) => await _customerRepository.UpdateAsync(customer);
        public async Task DeleteAsync(int id) => await _customerRepository.DeleteAsync(id);

        public async Task<List<Customer>> GetCustomersByPartySizeAsync(int minPartySize)
        {
            return await _customerRepository.GetCustomersByPartySizeAsync(minPartySize);
        }
    }
}
