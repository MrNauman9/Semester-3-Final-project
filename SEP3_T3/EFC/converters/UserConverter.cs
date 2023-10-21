using DTO;
using EFC.Entities;

namespace EFC.converters;

public class UserConverter
{
    public UserDTO ToDTO(UserEntity user) {
        return new UserDTO {
            Username = user.Username,
            Password = user.Password,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Telephone = user.Telephone,
            Role = user.Role
        };
    }

    public UserEntity ToEntity(UserDTO user) {
        return new UserEntity {
            Username = user.Username,
            Password = user.Password,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Telephone = user.Telephone,
            Role = user.Role
        };
    }
}