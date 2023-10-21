using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using DTO;

namespace Contracts; 

public interface IReservationService {
    Task<ReservationDTO> CreateReservation(CreateReservationDTO reservationDto);
    Task<List<ReservationDTO>> GetAllReservations();
    Task<List<ReservationDTO>> GetReservationsByUsername(string username);
    Task<ReservationDTO> GetReservationById(int reservationId);
    Task DeleteReservationById(int reservationId);
}