using Contracts;
using DTO;
using Grpc.Core;
using grpcProtoFiles;
using GrpcService.converters;

namespace GrpcService.GrpcController;

public class ReservationController : ReservationService.ReservationServiceBase {
    private readonly IReservationService _reservationService;
    private readonly ReservationConverter _reservationConverter;

    public ReservationController(IReservationService reservationService, ReservationConverter reservationConverter) {
        _reservationService = reservationService;
        _reservationConverter = reservationConverter;
    }

    public override async Task<CreateReservationResponse> createReservation(CreateReservationRequest request,
        ServerCallContext context) {
        CreateReservationDTO reservationToAdd = new() {
            ShowId = request.CircusShowId,
            NumOfSeats = request.NoOfTickets,
            ReservedBy = request.ReservedByUsername
        };
        var added = await _reservationService.AddReservation(reservationToAdd);
        return new CreateReservationResponse() {
            Reservation = _reservationConverter.ToProto(added)
        };
    }

    public override async Task<GetReservationResponse> getReservationById(GetReservationRequest request,
        ServerCallContext context) {
        var reservation = await _reservationService.GetReservation(request.Id);
        return new GetReservationResponse() {
            Reservation = _reservationConverter.ToProto(reservation)
        };
    }

    public override async Task<GetAllReservationsResponse> getAllReservations(GetAllReservationsRequest request,
        ServerCallContext context) {
        var reservations = await _reservationService.GetAllReservations();
        return new GetAllReservationsResponse() {
            Reservations = {_reservationConverter.ToListProto(reservations)}
        };
    }

    public override async Task<GetReservationsByUserResponse> getReservationsByUsername(
        GetReservationsByUserRequest request,
        ServerCallContext context) {
        var reservations = await _reservationService.GetReservationsByUser(request.Username);
        return new GetReservationsByUserResponse() {
            Reservations = {_reservationConverter.ToListProto(reservations)}
        };
    }
    
    public override async Task<deleteReservationResponse> deleteReservationById(deleteReservationByIdRequest request, ServerCallContext context)
    {
        ReservationDTO deletedReservation = await _reservationService.deleteReservationById(request.Id);
        // Instantiate a new CircusShow object and assign the converted data.
        return new deleteReservationResponse {  Reservation=_reservationConverter.ToProto(deletedReservation)};
    }
}