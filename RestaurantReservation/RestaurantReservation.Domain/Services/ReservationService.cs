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
        private readonly ICustomerRepository _customerRepository;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly ITableRepository _tableRepository;

        public ReservationService(
            IReservationRepository reservationRepository,
            ICustomerRepository customerRepository,
            IRestaurantRepository restaurantRepository,
            ITableRepository tableRepository)
        {
            _reservationRepository = reservationRepository;
            _customerRepository = customerRepository;
            _restaurantRepository = restaurantRepository;
            _tableRepository = tableRepository;
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

            if (!await _customerRepository.CustomerExistsAsync(reservation.CustomerId))
                throw new EntityNotFoundException($"Customer with ID {reservation.CustomerId} not found");

            if (!await _restaurantRepository.RestaurantExistsAsync(reservation.RestaurantId))
                throw new EntityNotFoundException($"Restaurant with ID {reservation.RestaurantId} not found");

            if (!await _tableRepository.TableExistsAsync(reservation.TableId))
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
            if (!await _customerRepository.CustomerExistsAsync(customerId))
                throw new EntityNotFoundException($"Customer with ID {customerId} not found");

            return await _reservationRepository.GetReservationsByCustomerAsync(customerId);
        }

        public async Task<List<ReservationView>> GetReservationsWithCustomerRestaurantAsync()
        {
            return await _reservationRepository.GetReservationsWithCustomerRestaurantAsync();
        }
    }
}