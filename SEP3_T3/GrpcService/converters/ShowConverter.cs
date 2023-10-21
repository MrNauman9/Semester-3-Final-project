using DTO;
using Google.Protobuf.Collections;
using grpcProtoFiles;
namespace GrpcService.converters;

public class ShowConverter
{
    public CircusShowDTO ToDto(CircusShow circusShow) {
        return new CircusShowDTO() {
            Id = circusShow.Id,
            Name = circusShow.Title,
            Description = circusShow.Description,
            Price = circusShow.Price,
            Location = circusShow.Locations.ToList(),
           
         
            
            duration  = circusShow.Duration,
            startTime  = circusShow.StartTime,
            endTime  = circusShow.EndTime,
            totalTicketsAvailable= circusShow.TotalTicketsAvailable,
        };
    }

    public List<CircusShowDTO> ToDtoList(RepeatedField<CircusShow> shows) {
        return shows.Select(ToDto).ToList();
    }

    public CircusShow ToProto(CircusShowDTO circusShowDto) {
        CircusShow circusShow = new CircusShow() {
            Id = circusShowDto.Id,
            Title = circusShowDto.Name,
            Description = circusShowDto.Description,
            Price = circusShowDto.Price,
            Duration  = circusShowDto.duration,
            StartTime  = circusShowDto.startTime,
            EndTime  = circusShowDto.endTime,
            TotalTicketsAvailable= circusShowDto.totalTicketsAvailable,
            Locations = {circusShowDto.Location},
        };

        return circusShow;    
    }

    public RepeatedField<CircusShow> ToProtoList(List<CircusShowDTO> circusShowDtos) {
        return new() {circusShowDtos.Select(ToProto).ToList()};
    }

}