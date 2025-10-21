using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.Db.Repositories
{
    public class TableRepository : BaseRepository<Table>
    {
        private readonly RestaurantReservationDbContext _context;

        public TableRepository(RestaurantReservationDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<bool> TableExistsAsync(int tableId)
        {
            return await _context.Tables.AnyAsync(t => t.TableId == tableId);
        }
    }
}
