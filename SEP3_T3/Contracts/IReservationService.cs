using DTO;

namespace Contracts;

public interface IReservationService
{
    Task<ReservationDTO> AddReservation(CreateReservationDTO reservation);
    Task<ReservationDTO> GetReservation(int id);
    Task<List<ReservationDTO>> GetAllReservations();
    Task<List<ReservationDTO>> GetReservationsByUser(string username);
    Task<ReservationDTO> deleteReservationById(int reservationId);
}
