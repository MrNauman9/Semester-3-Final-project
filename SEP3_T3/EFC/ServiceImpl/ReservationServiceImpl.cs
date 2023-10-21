using Contracts;
using DTO;
using EFC.converters;
using EFC.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFC.ServiceImpl;

public class 
    ReservationServiceImpl : IReservationService {
    private readonly ReservationConverter _reservationConverter;
    private readonly DatabaseAccess _databaseAccess;

    public ReservationServiceImpl(ReservationConverter reservationConverter, DatabaseAccess databaseAccess) {
        _reservationConverter = reservationConverter;
        this._databaseAccess = databaseAccess;
    }

    public async Task<ReservationDTO> AddReservation(CreateReservationDTO reservation) {
        ReservationEntity reservationEntity = new ReservationEntity() {
            noOfTickets = reservation.NumOfSeats,
            
        };
        reservationEntity.ReservedBy= (await _databaseAccess.Users.FindAsync(reservation.ReservedBy))!;
        reservationEntity.Show =(await _databaseAccess.Shows.FindAsync(reservation.ShowId))!;
        var added = await _databaseAccess.Reservations.AddAsync(reservationEntity);
        await _databaseAccess.SaveChangesAsync();
        return _reservationConverter.ToDto(added.Entity);
    }

    public async Task<ReservationDTO> GetReservation(int id) {
        var reservation = await _databaseAccess.Reservations.Include(entity => entity.ReservedBy)
            .Include(entity => entity.Show)
            .FirstOrDefaultAsync(entity => entity.Id == id);
        if (reservation == null) {
            throw new Exception("Reservation not found");
        }

        return _reservationConverter.ToDto(reservation);
    }

    public async Task<List<ReservationDTO>> GetAllReservations() {
        var reservations = await _databaseAccess.Reservations.Include(entity => entity.ReservedBy)
            .Include(entity => entity.Show).ThenInclude(show=>show.ShowLocations).ToListAsync();
        return _reservationConverter.ToDtoList(reservations);
    }

    public async Task<List<ReservationDTO>> GetReservationsByUser(string username) {
        var reservations = await _databaseAccess.Reservations.Include(entity => entity.ReservedBy)
            .Include(entity => entity.Show)
            .Where(entity => entity.ReservedBy.Username == username).ToListAsync();
        if (reservations == null) {
            throw new Exception("Reservation not found");
        }

        return _reservationConverter.ToDtoList(reservations);
    }

    public async  Task<ReservationDTO> deleteReservationById(int reservationId)
    {
        var existing = await GetReservation(reservationId);
     
        if (existing == null)
        {
            throw new Exception($"ReservationDTO with id {reservationId} not found");
        }

        var reservationEntity=_reservationConverter.ToEntity(existing);
        _databaseAccess.Reservations.Remove(reservationEntity); 
        await _databaseAccess.SaveChangesAsync();
        return _reservationConverter.ToDto(reservationEntity);
    }
}