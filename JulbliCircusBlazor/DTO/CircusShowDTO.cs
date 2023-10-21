namespace DTO; 

public class CircusShowDTO {
    public int Id { get; set; }
    public string title { get; set; }
    public string? Description { get; set; }
    public double Price{ get; set; }
    public string duration { get; set; }
    public string startTime { get; set; }
    public string endTime { get; set; }

    public double totalTicketsAvailable{ get; set; }

    public List<string>? Location { get; set; }
}                                