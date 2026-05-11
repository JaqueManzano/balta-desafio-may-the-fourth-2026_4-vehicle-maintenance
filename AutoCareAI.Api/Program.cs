using AutoCareAI.Ai.Agents;
using AutoCareAI.Ai.Providers.Astractions;
using AutoCareAI.Api.Services;
using AutoCareAI.Core.Agents.Abstractions;
using AutoCareAI.Core.Enums;
using AutoCareAI.Core.Models;
using Moving.Ai.Providers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//
// CSV Parser
//
builder.Services.AddScoped<
    IVehicleTelemetryCsvParser,
    VehicleTelemetryCsvParser>();

//
// Prompt Provider
//
builder.Services.AddKeyedScoped<IPromptProvider, FilePromptProvider>(
    PromptProvider.File);

//
// Agent
//
builder.Services.AddScoped<
    IAgent<VehicleMaintenanceAnalysisRequest, string>,
    VehicleMaintenanceAgent>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();