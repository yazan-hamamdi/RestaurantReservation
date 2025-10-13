using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Repositories
{
    public class RestaurantRepository : BaseRepository<Restaurant> , IRestaurantRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public RestaurantRepository(RestaurantReservationDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<decimal> CalculateTotalRevenueAsync(int restaurantId)
        {
            var revenue = await _context.Database
               .SqlQueryRaw<decimal>("SELECT CalculateTotalRevenue({0})", restaurantId)
               .SingleAsync();

            return revenue;
        }
    }
}