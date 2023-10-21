using Contracts;
using DTO;
using Grpc.Core;
using grpcProtoFiles;
using GrpcService.converters;

namespace GrpcService.GrpcController;

public class ShowController : CircusShowService.CircusShowServiceBase {
    private readonly ICircusShowService _circusShowService;
    private readonly ShowConverter _circusShowConverter;

    public ShowController(ICircusShowService circusShowService, ShowConverter circusShowConverter) {
        _circusShowService = circusShowService;
        _circusShowConverter = circusShowConverter;
    }
    public override async Task<CreateCircusShowResponse> createCircusShow(CreateCircusShowRequest request, ServerCallContext context) {
        CircusShowDTO circusShowDto= _circusShowConverter.ToDto(request.CircusShow);
        CircusShowDTO addedCircusShow = await _circusShowService.AddShow(circusShowDto);
        return new CreateCircusShowResponse() {
            CircusShow = _circusShowConverter.ToProto(addedCircusShow)
        };
    }

    public override async Task<CircusShowByIdResponse> getCircusShowById(CircusShowByIdRequest request, ServerCallContext context) {
       // int id = request.Id;
        CircusShowDTO circusShowDto = await _circusShowService.GetCircusShowById(request.Id);
        return new CircusShowByIdResponse() {
            CircusShow = _circusShowConverter.ToProto(circusShowDto)
        };
    }


    public override async Task<GetAllCircusShowResponse> getAllCircusShows(getAllCircusShowsRequest request, ServerCallContext context) {
        List<CircusShowDTO> allCircusShows = await _circusShowService.GetAllShows();
        return new GetAllCircusShowResponse() {
            CircusShow = {_circusShowConverter.ToProtoList(allCircusShows)}
        };
    }

    public override async Task<getAllCircusShowsByLocationResponse> getAllCircusShowsByLocation(getAllCircusShowsByLocationRequest request, ServerCallContext context) {
        //may request.location is wrong= sting id = request.Id;
        List<CircusShowDTO> circusShowsByName = await _circusShowService.GetShowsByLocation(request.Location);
        return new getAllCircusShowsByLocationResponse() {
            CircusShow = {_circusShowConverter.ToProtoList(circusShowsByName)}
        };

    }

    public override async Task<DeleteCircusShowResponse> DeleteCircusShow(Integer request, ServerCallContext context)
    {
        CircusShowDTO deletedCircusShow = await _circusShowService.deleteCircusShow(request.Id);
        // Instantiate a new CircusShow object and assign the converted data.
        return new DeleteCircusShowResponse() { CircusShow=_circusShowConverter.ToProto(deletedCircusShow)};
    }
}

    
    
