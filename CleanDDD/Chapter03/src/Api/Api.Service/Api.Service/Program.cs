using Api.Infrastructure.Abstractions.Registrations;
using Api.Service.Abstractions.Registrations;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services
    .RegisterGrpc()
    .RegisterWolverine()
    .RegisterRepository();

var app = builder.Build();

app.UsingSwagger();
app.MapGrpcControllers();
app.Run();

public partial class Program { }