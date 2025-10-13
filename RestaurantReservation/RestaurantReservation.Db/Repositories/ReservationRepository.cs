using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Repositories
{
    public class ReservationRepository : BaseRepository<Reservation> , IReservationRepository
    {
        public ReservationRepository(RestaurantReservationDbContext context) : base(context) { }
    }
}
