using RestaurantReservation.Db.DataModels;


namespace RestaurantReservation.Db.Interfaces
{
    public interface ITableRepository : IBaseRepository<Table>
    {
        Task<bool> TableExistsAsync(int tableId);
    }
}
