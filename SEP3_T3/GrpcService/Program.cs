using Contracts;
using EFC;
using EFC.converters;
using EFC.ServiceImpl;
using GrpcService.GrpcController;


var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddDbContext<DatabaseAccess>();
builder.Services.AddGrpc();
builder.Services.AddScoped<IUserService, UserServiceImpl>();
builder.Services.AddScoped<ICircusShowService, CircusShowServiceImpl>();
builder.Services.AddScoped<IReservationService, ReservationServiceImpl>();
builder.Services.AddScoped<ShowConverter>();
builder.Services.AddScoped<ReservationConverter>();
builder.Services.AddScoped<UserConverter>();
builder.Services.AddScoped<GrpcService.converters.UserConverter>();
builder.Services.AddScoped<GrpcService.converters.ShowConverter>();
builder.Services.AddScoped<GrpcService.converters.ReservationConverter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<UserController>();
app.MapGrpcService<ReservationController>();
app.MapGrpcService<ShowController>();
//app.MapGrpcService<GreeterService>();
app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();