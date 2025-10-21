using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.Db.Interfaces
{
    public interface IOrderItemRepository : IBaseRepository<OrderItem>
    {
        Task<bool> OrderExistsAsync(int orderId);
        Task<bool> MenuItemExistsAsync(int menuItemId);
    }
}
