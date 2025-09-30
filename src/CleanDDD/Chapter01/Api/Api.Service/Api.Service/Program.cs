using Api.Service.Abstractions.Registrations;
using Api.Application.Abstractions.Registrations;
using Api.Infrastructure.Abstractions.Registrations;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .RegisterGrpc()
    .RegisterMediator()
    .RegisterRepository();

var app = builder.Build();

app.UsingSwagger();
app.MapGrpcControllers();
app.Run();
