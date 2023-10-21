namespace DTO;

public class ReservationDTO
{
    public int Id { get; set; }
    public UserDTO ReservedBy { get; set; }
    public CircusShowDTO Show { get; set; }
    public int NoOfTickets { get; set; }
   // public bool IsDelivered { get; set; }
}