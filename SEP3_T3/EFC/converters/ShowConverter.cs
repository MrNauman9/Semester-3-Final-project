using DTO;
using EFC.Entities;

namespace EFC.converters;

public class ShowConverter
{public CircusShowDTO ToDto(ShowEntity show) {
        return new CircusShowDTO{
            Id = show.Id,
            Name = show.Name,
            Description = show.Description,
            Price = show.Price,
            duration  = show.duration,
            startTime  = show.startTime,
            endTime  = show.endTime,
            totalTicketsAvailable= show.totalTicketsAvailable,

            Location = show.ShowLocations == null ? new List<string>() : show.ShowLocations.Select(i => i.LocationName).ToList()
        };
    }

    public List<CircusShowDTO> ToDtoList(List<ShowEntity> entities) {
        return entities.Select(ToDto).ToList();

    }

    public ShowEntity ToEntity(CircusShowDTO show) {
        return new ShowEntity {
            Id = show.Id,
            Name = show.Name,
            Description = show.Description,
            Price = show.Price,
            duration  = show.duration,
            startTime  = show.startTime,
            endTime  = show.endTime,
            totalTicketsAvailable= show.totalTicketsAvailable,
            ShowLocations = show.Location == null ? new List<ShowLocationEntity>() : show.Location.Select(locationString => new ShowLocationEntity(){LocationName = locationString}).ToList()
        };
    }
    
}