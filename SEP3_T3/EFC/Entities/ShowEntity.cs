using System.ComponentModel.DataAnnotations;

namespace EFC.Entities;

public class ShowEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string? Description { get; set; }
    public double Price{ get; set; }
    public String duration { get; set; }
    public String startTime{ get; set; }
    public String endTime{ get; set; }
    public double totalTicketsAvailable{ get; set; }
    public List<ShowLocationEntity>? ShowLocations { get; set; }

}