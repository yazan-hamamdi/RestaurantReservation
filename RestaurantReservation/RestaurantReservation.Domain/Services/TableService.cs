using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Domain.Exceptions;
using RestaurantReservation.Domain.IServices;

namespace RestaurantReservation.Domain.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;
        private readonly RestaurantReservationDbContext _context;

        public TableService(ITableRepository repository, RestaurantReservationDbContext context)
        {
            _tableRepository = repository;
            _context = context;
        }

        public async Task<List<Table>> GetAllAsync() =>
            await _tableRepository.GetAllAsync();

        public async Task<Table> GetByIdAsync(int id)
        {
            var table = await _tableRepository.GetByIdAsync(id);
            if (table == null)
                throw new EntityNotFoundException($"Table with ID {id} not found");

            return table;
        }

        public async Task AddAsync(Table table)
        {
            if (table == null)
                throw new ArgumentNullException(nameof(table));

            var restaurantExists = await _context.Restaurants.AnyAsync(r => r.RestaurantId == table.RestaurantId);
            if (!restaurantExists)
                throw new EntityNotFoundException($"Restaurant with ID {table.RestaurantId} not found");

            await _tableRepository.AddAsync(table);
        }

        public async Task UpdateAsync(Table table)
        {
            if (table == null)
                throw new ArgumentNullException(nameof(table));

            var existing = await _tableRepository.GetByIdAsync(table.TableId);
            if (existing == null)
                throw new EntityNotFoundException($"Table with ID {table.TableId} not found");

            await _tableRepository.UpdateAsync(table);
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _tableRepository.GetByIdAsync(id);
            if (existing == null)
                throw new EntityNotFoundException($"Table with ID {id} not found");

            await _tableRepository.DeleteAsync(id);
        }
    }
}
