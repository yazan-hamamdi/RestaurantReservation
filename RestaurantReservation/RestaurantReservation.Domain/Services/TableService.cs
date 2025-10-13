using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Domain.IServices;

namespace RestaurantReservation.Domain.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _repository;

        public TableService(ITableRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Table>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Table?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task AddAsync(Table table) => await _repository.AddAsync(table);
        public async Task UpdateAsync(Table table) => await _repository.UpdateAsync(table);
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}
