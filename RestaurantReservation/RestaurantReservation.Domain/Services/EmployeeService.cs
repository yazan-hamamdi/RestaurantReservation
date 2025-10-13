using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Domain.IServices;

namespace RestaurantReservation.Domain.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly RestaurantReservationDbContext _context;

        public EmployeeService(IEmployeeRepository employeeRepository, RestaurantReservationDbContext context)
        {
            _employeeRepository = employeeRepository;
            _context = context;
        }

        public async Task<List<Employee>> GetAllAsync() => await _employeeRepository.GetAllAsync();
        public async Task<Employee?> GetByIdAsync(int id) => await _employeeRepository.GetByIdAsync(id);
        public async Task AddAsync(Employee employee) => await _employeeRepository.AddAsync(employee);
        public async Task UpdateAsync(Employee employee) => await _employeeRepository.UpdateAsync(employee);
        public async Task DeleteAsync(int id) => await _employeeRepository.DeleteAsync(id);

        public async Task<List<Employee>> ListManagersAsync()
        {
            const string managerRole = "Manager";

            return await _context.Employees
                .Where(e => e.Position == managerRole)
                .ToListAsync();
        }
    }
}
