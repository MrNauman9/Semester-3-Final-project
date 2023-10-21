using System.ComponentModel.DataAnnotations;

namespace EFC.Entities;

public class LocationEntity
{
    [Key]
    public string LocationName { get; set; }

    public List<ShowLocationEntity> ShowLocations { get; set; }

}