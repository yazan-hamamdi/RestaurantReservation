using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.Domain.IServices
{
    public interface IOrderService : IBaseService<Order>
    {
        Task<List<Order>> ListOrdersAndMenuItemsAsync(int reservationId);
        Task<decimal> CalculateAverageOrderAmountAsync(int employeeId);
    }
}
