using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Db.ViewDTOs;
using RestaurantReservation.Domain.Exceptions;
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

        public async Task<List<Reservation>> GetAllAsync() =>
            await _reservationRepository.GetAllAsync();

        public async Task<Reservation> GetByIdAsync(int id)
        {
            var reservation = await _reservationRepository.GetByIdAsync(id);
            if (reservation == null)
                throw new EntityNotFoundException($"Reservation with ID {id} not found");

            return reservation;
        }

        public async Task AddAsync(Reservation reservation)
        {
            if (reservation == null)
                throw new ArgumentNullException(nameof(reservation));

            var customerExists = await _context.Customers.AnyAsync(c => c.CustomerId == reservation.CustomerId);
            if (!customerExists)
                throw new EntityNotFoundException($"Customer with ID {reservation.CustomerId} not found");

            var restaurantExists = await _context.Restaurants.AnyAsync(r => r.RestaurantId == reservation.RestaurantId);
            if (!restaurantExists)
                throw new EntityNotFoundException($"Restaurant with ID {reservation.RestaurantId} not found");

            var tableExists = await _context.Tables.AnyAsync(t => t.TableId == reservation.TableId);
            if (!tableExists)
                throw new EntityNotFoundException($"Table with ID {reservation.TableId} not found");

            await _reservationRepository.AddAsync(reservation);
        }

        public async Task UpdateAsync(Reservation reservation)
        {
            if (reservation == null)
                throw new ArgumentNullException(nameof(reservation));

            var existing = await _reservationRepository.GetByIdAsync(reservation.ReservationId);
            if (existing == null)
                throw new EntityNotFoundException($"Reservation with ID {reservation.ReservationId} not found");

            await _reservationRepository.UpdateAsync(reservation);
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _reservationRepository.GetByIdAsync(id);
            if (existing == null)
                throw new EntityNotFoundException($"Reservation with ID {id} not found");

            await _reservationRepository.DeleteAsync(id);
        }

        public async Task<List<Reservation>> GetReservationsByCustomerAsync(int customerId)
        {
            var customerExists = await _context.Customers.AnyAsync(c => c.CustomerId == customerId);
            if (!customerExists)
                throw new EntityNotFoundException($"Customer with ID {customerId} not found");

            return await _context.Reservations
                .Where(r => r.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<List<ReservationView>> GetReservationsWithCustomerRestaurantAsync()
        {
            return await _context.ReservationViews
                .OrderBy(r => r.ReservationDate)
                .ToListAsync();
        }
    }
}