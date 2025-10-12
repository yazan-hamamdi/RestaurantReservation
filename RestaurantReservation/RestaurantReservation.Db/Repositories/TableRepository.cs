using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.Db.Repositories
{
    public class TableRepository : BaseRepository<Table>
    {
        public TableRepository(RestaurantReservationDbContext context) : base(context) { }
    }
}
