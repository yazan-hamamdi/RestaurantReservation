using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Repositories
{
    public class CustomerRepository : BaseRepository<Customer> , ICustomerRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public CustomerRepository(RestaurantReservationDbContext context) : base(context) 
        { 
           _context = context;
        }

        public async Task<List<Customer>> GetCustomersByPartySizeAsync(int minPartySize)
        {
            return await _context.Customers
                .FromSqlRaw("EXEC GetCustomersByPartySize @MinPartySize={0}", minPartySize)
                .ToListAsync();
        }
        public async Task<bool> CustomerExistsAsync(int customerId)
        {
            return await _context.Customers.AnyAsync(c => c.CustomerId == customerId);
        }
    }
}
