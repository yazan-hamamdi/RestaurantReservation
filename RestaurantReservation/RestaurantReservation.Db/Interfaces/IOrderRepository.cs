using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.Db.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<bool> ReservationExistsAsync(int reservationId);
        Task<bool> EmployeeExistsAsync(int employeeId);
        Task<List<Order>> ListOrdersAndMenuItemsAsync(int reservationId);
        Task<decimal> CalculateAverageOrderAmountAsync(int employeeId);
    }
}
