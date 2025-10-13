using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Domain.IServices;

namespace RestaurantReservation.Domain.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;

        public TableService(ITableRepository repository)
        {
            _tableRepository = repository;
        }

        public async Task<List<Table>> GetAllAsync() => await _tableRepository.GetAllAsync();
        public async Task<Table?> GetByIdAsync(int id) => await _tableRepository.GetByIdAsync(id);
        public async Task AddAsync(Table table) => await _tableRepository.AddAsync(table);
        public async Task UpdateAsync(Table table) => await _tableRepository.UpdateAsync(table);
        public async Task DeleteAsync(int id) => await _tableRepository.DeleteAsync(id);
    }
}
