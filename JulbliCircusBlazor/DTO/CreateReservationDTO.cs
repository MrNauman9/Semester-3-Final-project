namespace DTO; 

public class CreateReservationDTO {

    public string ReservedBy { get; set; }
    public int circusShowId { get; set; }
    public int noOfTickets { get; set; }

}