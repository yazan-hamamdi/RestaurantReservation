using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Domain.IServices;

namespace RestaurantReservation.Domain.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Employee>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Employee?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task AddAsync(Employee employee) => await _repository.AddAsync(employee);
        public async Task UpdateAsync(Employee employee) => await _repository.UpdateAsync(employee);
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}
