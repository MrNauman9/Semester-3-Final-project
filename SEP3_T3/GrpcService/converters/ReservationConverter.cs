using DTO;

using Google.Protobuf.Collections;
using grpcProtoFiles;

namespace GrpcService.converters;

public class ReservationConverter
{
    private readonly UserConverter _userConverter;
    private readonly ShowConverter _circusShowConverter;

    public ReservationConverter(UserConverter userConverter, ShowConverter circusShowConverter) {
        _userConverter = userConverter;
        _circusShowConverter = circusShowConverter;
    }


    public ReservationDTO ToDto(Reservation reservation) {
        return new ReservationDTO() {
            Id = reservation.Id,
            ReservedBy = _userConverter.ToDto(reservation.ReservedBy),
            Show = _circusShowConverter.ToDto(reservation.CircusShow),
            NoOfTickets = reservation.NoOfTickets
            
        };
    }

    public List<ReservationDTO> ToListDto(RepeatedField<Reservation> reservations) {
        return reservations.Select(ToDto).ToList();
    }

    public Reservation ToProto(ReservationDTO reservationDto) {
        return new Reservation() {
            Id = reservationDto.Id,
            ReservedBy = _userConverter.ToProto(reservationDto.ReservedBy),
            CircusShow = _circusShowConverter.ToProto(reservationDto.Show),
            NoOfTickets = reservationDto.NoOfTickets
            
        };
    }

    public RepeatedField<Reservation> ToListProto(List<ReservationDTO> reservations) {
        return new RepeatedField<Reservation>(){reservations.Select(ToProto).ToList()};
    }
}