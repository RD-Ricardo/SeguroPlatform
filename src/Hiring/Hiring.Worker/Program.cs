using Hiring.Worker;
using Hiring.Application.UseCases;
using SeguroPlataform.Common.Configuration;
using Hiring.Application.Ports.Inbound.UseCases.CreateHiring;
using Hiring.Database;

var builder = Host.CreateApplicationBuilder(args);

var channel = builder.Services.CreateAmqpChannel(builder.Configuration).GetAwaiter().GetResult();

builder.Services.AddScoped<ICreateHiringUseCase, CreateHiringUseCase>();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
