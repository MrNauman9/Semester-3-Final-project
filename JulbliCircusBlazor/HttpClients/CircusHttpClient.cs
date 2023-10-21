using Contracts;
using DTO;

namespace HttpClients; 

public class CircusHttpClient : ICircusService {
    /// <summary>
    /// Need To Change all endpoints here
    /// </summary>
    /// <param name="circusShowDTO"></param>
    /// <returns></returns>
    public async Task<CircusShowDTO> CreateCircusShow(CircusShowDTO circusShowDTO) {
        return await HttpClientUtil.SendHttpPostRequest<CircusShowDTO, CircusShowDTO>("circusShows", circusShowDTO);
    }

    public async Task<CircusShowDTO> DeleteCircusShow(int circusShowId)
    {
        return await HttpClientUtil.SendHttpDeleteRequestNoToken<CircusShowDTO, CircusShowDTO>($"circusShows/{circusShowId}");
    }

    public async Task<List<CircusShowDTO>> GetAllCircusShows() {
        return await HttpClientUtil.SendHttpGetRequestNoToken<CircusShowDTO, List<CircusShowDTO>>("circusShows");
    }

    public async Task<List<CircusShowDTO>> GetAllCircusShowsByLocation(string location) {
        return await HttpClientUtil.SendHttpGetRequest<CircusShowDTO, List<CircusShowDTO>>($"circusShows?location={location}");
    }

    public async Task<CircusShowDTO> GetCircusShowById(int id) {
        return await HttpClientUtil.SendHttpGetRequest<CircusShowDTO, CircusShowDTO>($"circusShows/{id}");
    }
}