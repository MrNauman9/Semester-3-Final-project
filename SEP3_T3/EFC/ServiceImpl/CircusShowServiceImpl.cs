using Contracts;
using DTO;
using EFC.converters;
using EFC.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFC.ServiceImpl;

public class CircusShowServiceImpl : ICircusShowService {
    private readonly DatabaseAccess _databaseAccess;
    private readonly ShowConverter _showConverter;

    public CircusShowServiceImpl(DatabaseAccess databaseAccess, ShowConverter showConverter) {
        _databaseAccess = databaseAccess;
        _showConverter = showConverter;
    }

    public async Task<CircusShowDTO> AddShow(CircusShowDTO showDto) {
        var showEntity = _showConverter.ToEntity(showDto);
        await AddLocationsIfNotExists(showEntity);
        var addedShow = await _databaseAccess.Shows.AddAsync(showEntity);
        await _databaseAccess.SaveChangesAsync();
        return _showConverter.ToDto(addedShow.Entity);
    }

    private async Task AddLocationsIfNotExists(ShowEntity showEntity) {
        List<ShowLocationEntity>? showLocationEntities = showEntity.ShowLocations;
        if (showLocationEntities == null) return; 
        foreach (var showLocationEntity in showLocationEntities) {
          var location = await _databaseAccess.Locations.FindAsync(showLocationEntity.LocationName);
          if (location == null){
              await _databaseAccess.Locations.AddAsync(new LocationEntity(){LocationName = showLocationEntity.LocationName});
          }
        }
    }

    public async Task<CircusShowDTO> GetCircusShowById(int id) {
        var showById = await _databaseAccess.Shows.Include(entity => entity!.ShowLocations!)
            .ThenInclude(showLocation => showLocation.Location).FirstOrDefaultAsync(show => show.Id == id);
        if (showById == null) {
            throw new Exception("Show not found");
        }
        return _showConverter.ToDto(showById);
    }


    public async Task<List<CircusShowDTO>> GetAllShows() {
        var shows = await _databaseAccess.Shows.Include(entity => entity!.ShowLocations!)
            .ThenInclude(showLocation => showLocation.Location).ToListAsync();
        return shows.Select(show => _showConverter.ToDto(show)).ToList();
        
    }

    public async Task<List<CircusShowDTO>> GetShowsByLocation(string requestName) {
        var shows = await _databaseAccess.Shows.Include(entity => entity!.ShowLocations!)
            .ThenInclude(showLocation => showLocation.Location).Where(show => show.Name.ToUpper().Contains(requestName.ToUpper())).ToListAsync();
        return _showConverter.ToDtoList(shows); 
    }

    public async Task<CircusShowDTO> deleteCircusShow(int circusShowId)
    {
     /*var showEntity = _showConverter.ToEntity(showDto);
        await AddLocationsIfNotExists(showEntity);
        var addedShow = await _databaseAccess.Shows.AddAsync(showEntity);
        await _databaseAccess.SaveChangesAsync();
        return _showConverter.ToDto(addedShow.Entity);*/
     var existing = await GetCircusShowById(circusShowId);
     
     if (existing == null)
     {
         throw new Exception($"CircusShow with id {circusShowId} not found");
     }

     var showEntity=_showConverter.ToEntity(existing);
     _databaseAccess.Shows.Remove(showEntity); 
     await _databaseAccess.SaveChangesAsync();
     return _showConverter.ToDto(showEntity);
    }
    
}

