using DTO;
using EFC.Entities;

namespace EFC.converters;

public class ReservationConverter
{
    private readonly UserConverter userConverter;
    private readonly ShowConverter showConverter;

    public ReservationConverter(UserConverter userConverter, ShowConverter showConverter) {
        this.userConverter = userConverter;
        this.showConverter = showConverter;
    }

    public ReservationDTO ToDto(ReservationEntity entity) {
        return new ReservationDTO() {
            Id = entity.Id,
            ReservedBy = userConverter.ToDTO(entity.ReservedBy),
            Show = showConverter.ToDto(entity.Show),
            NoOfTickets = entity.noOfTickets,
          
        };
    }

    public List<ReservationDTO> ToDtoList(List<ReservationEntity> entities) {
        return entities.Select(ToDto).ToList();
    }

    public ReservationEntity ToEntity(ReservationDTO dto) {
        return new ReservationEntity() {
            Id = dto.Id,
            ReservedBy = userConverter.ToEntity(dto.ReservedBy),
            Show = showConverter.ToEntity(dto.Show),
            noOfTickets =  dto.NoOfTickets,
            
        };
    }

}