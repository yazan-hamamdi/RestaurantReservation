using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Db.NewFolder;
using RestaurantReservation.Db.ViewDTOs;

namespace RestaurantReservation.Db.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee> , IEmployeeRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public EmployeeRepository(RestaurantReservationDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<Employee>> ListManagersAsync()
        {
            var managerRole = EmployeeRole.Manager;

            return await _context.Employees
                .Where(e => e.Position ==managerRole.ToString())
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
