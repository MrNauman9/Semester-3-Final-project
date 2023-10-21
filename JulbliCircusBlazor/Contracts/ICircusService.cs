using DTO;

namespace Contracts; 

public interface ICircusService {
    Task<CircusShowDTO> CreateCircusShow(CircusShowDTO circusShowDto);
    Task<List<CircusShowDTO>> GetAllCircusShows();
    Task<List<CircusShowDTO>> GetAllCircusShowsByLocation(string username);
    Task<CircusShowDTO> GetCircusShowById(int id);
    Task<CircusShowDTO> DeleteCircusShow(int circusShowId);

}