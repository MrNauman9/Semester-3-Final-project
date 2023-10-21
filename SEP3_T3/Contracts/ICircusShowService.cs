using DTO;

namespace Contracts;

public interface ICircusShowService
{
    Task<CircusShowDTO> AddShow(CircusShowDTO circusShowDto);
    Task<CircusShowDTO> GetCircusShowById(int id);
    Task<List<CircusShowDTO>> GetAllShows();
    Task<List<CircusShowDTO>> GetShowsByLocation(string requestLocation);
    Task<CircusShowDTO> deleteCircusShow(int  circusShowId);
}