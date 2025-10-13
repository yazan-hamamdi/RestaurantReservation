using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Db.ViewDTOs;
using RestaurantReservation.Domain.Exceptions;
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

        public async Task<List<Employee>> GetAllAsync() =>
            await _employeeRepository.GetAllAsync();

        public async Task<Employee?> GetByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
                throw new EntityNotFoundException($"Employee with ID {id} not found");

            return employee;
        }

        public async Task AddAsync(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            await _employeeRepository.AddAsync(employee);
        }

        public async Task UpdateAsync(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            var existing = await _employeeRepository.GetByIdAsync(employee.EmployeeId);
            if (existing == null)
                throw new EntityNotFoundException($"Cannot update employee — ID {employee.EmployeeId} not found");

            await _employeeRepository.UpdateAsync(employee);
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _employeeRepository.GetByIdAsync(id);
            if (existing == null)
                throw new EntityNotFoundException($"Cannot delete employee — ID {id} not found");

            await _employeeRepository.DeleteAsync(id);
        }

        public async Task<List<Employee>> ListManagersAsync()
        {
            const string ManagerRole = "Manager";

            return await _context.Employees
                .Where(e => e.Position == ManagerRole)
                .ToListAsync();
        }

        public async Task<List<EmployeeView>> GetEmployeesWithRestaurantAsync()
        {
            return await _context.EmployeeViews
                .OrderBy(e => e.LastName)
                .ToListAsync();
        }
    }
}
