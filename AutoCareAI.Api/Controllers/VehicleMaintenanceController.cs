using AutoCareAI.Api.Requests;
using AutoCareAI.Core.Agents.Abstractions;
using AutoCareAI.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoCareAI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehicleMaintenanceController : ControllerBase
{
    private readonly IVehicleTelemetryCsvParser _parser;

    private readonly IAgent<
        VehicleMaintenanceAnalysisRequest,
        string> _agent;

    public VehicleMaintenanceController(
        IVehicleTelemetryCsvParser parser,
        IAgent<VehicleMaintenanceAnalysisRequest, string> agent)
    {
        _parser = parser;
        _agent = agent;
    }

    [HttpPost("analyze")]
    public async Task<IActionResult> Analyze(
        [FromForm] VehicleTelemetryAnalysisRequest request,
        CancellationToken cancellationToken)
    {
        var records = await _parser.ParseAsync(
            request.File,
            cancellationToken);

        var analysisRequest =
            new VehicleMaintenanceAnalysisRequest
            {
                Vehicle = new VehicleInformation
                {
                    Brand = request.Brand,
                    Model = request.Model,
                    Year = request.Year,
                    Engine = request.Engine
                },

                Records = records
            };

        var result = await _agent.RunAsync(
            analysisRequest,
            cancellationToken);

        return Ok(result);
    }
}