using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Domain.IServices;

namespace RestaurantReservation.Domain.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly RestaurantReservationDbContext _context;

        public ReservationService(IReservationRepository repository, RestaurantReservationDbContext context)
        {
            _reservationRepository = repository;
            _context = context;
        }

        public async Task<List<Reservation>> GetAllAsync() => await _reservationRepository.GetAllAsync();
        public async Task<Reservation?> GetByIdAsync(int id) => await _reservationRepository.GetByIdAsync(id);
        public async Task AddAsync(Reservation reservation) => await _reservationRepository.AddAsync(reservation);
        public async Task UpdateAsync(Reservation reservation) => await _reservationRepository.UpdateAsync(reservation);
        public async Task DeleteAsync(int id) => await _reservationRepository.DeleteAsync(id);

        public async Task<List<Reservation>> GetReservationsByCustomerAsync(int customerId)
        {
            return await _context.Reservations
                .Where(r => r.CustomerId == customerId)
                .ToListAsync();
        }
    }
}