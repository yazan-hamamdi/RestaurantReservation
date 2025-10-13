using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Domain.IServices;

namespace RestaurantReservation.Domain.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _repository;

        public ReservationService(IReservationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Reservation>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Reservation?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task AddAsync(Reservation reservation) => await _repository.AddAsync(reservation);
        public async Task UpdateAsync(Reservation reservation) => await _repository.UpdateAsync(reservation);
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}
