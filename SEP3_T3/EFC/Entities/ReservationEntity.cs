using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EFC.Entities;

public class ReservationEntity
{
    [Key]
    public int Id { get; set; }

    public int noOfTickets { get; set; }

    [DefaultValue(false)]
    public UserEntity ReservedBy { get; set; }
    public ShowEntity Show { get; set; }
}