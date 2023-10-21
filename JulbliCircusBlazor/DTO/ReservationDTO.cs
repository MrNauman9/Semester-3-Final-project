namespace DTO; 

public class ReservationDTO {
    public int Id { get; set; }
    public UserDTO ReservedBy { get; set; }
    public CircusShowDTO circusShowDto { get; set; }
    public int noOfTickets { get; set; }
    

}