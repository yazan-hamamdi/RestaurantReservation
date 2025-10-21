using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.Db.Interfaces
{
    public interface IMenuItemRepository : IBaseRepository<MenuItem>
    {
        Task<List<MenuItem>> ListOrderedMenuItemsAsync(int reservationId);
    }
}
