using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Domain.Exceptions;
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

        public async Task<List<Customer>> GetAllAsync() =>
            await _customerRepository.GetAllAsync();

        public async Task<Customer?> GetByIdAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
                throw new EntityNotFoundException($"Customer with ID {id} not found");

            return customer;
        }

        public async Task AddAsync(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            await _customerRepository.AddAsync(customer);
        }

        public async Task UpdateAsync(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            var existing = await _customerRepository.GetByIdAsync(customer.CustomerId);
            if (existing == null)
                throw new EntityNotFoundException($"Cannot update — Customer with ID {customer.CustomerId} not found");

            await _customerRepository.UpdateAsync(customer);
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _customerRepository.GetByIdAsync(id);
            if (existing == null)
                throw new EntityNotFoundException($"Cannot delete — Customer with ID {id} not found");

            await _customerRepository.DeleteAsync(id);
        }

        public async Task<List<Customer>> GetCustomersByPartySizeAsync(int minPartySize)
        {
            if (minPartySize <= 0)
                throw new ArgumentException("Party size must be greater than zero", nameof(minPartySize));

            return await _customerRepository.GetCustomersByPartySizeAsync(minPartySize);
        }
    }
}
