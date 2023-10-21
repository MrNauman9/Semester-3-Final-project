namespace EFC.Entities;

public class ShowLocationEntity
{
    public int ShowId { get; set; }
    public ShowEntity Show { get; set; }

    public string LocationName { get; set; }
    public LocationEntity Location { get; set; }
}