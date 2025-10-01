using Api.Infrastructure.Abstractions.Registrations;
using Api.Service.Abstractions.Registrations;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .RegisterGrpc()
    .RegisterWolverine()
    .RegisterRepository();

var app = builder.Build();

app.UsingSwagger();
app.MapGrpcControllers();
app.Run();
