using AutoCareAI.Core.Models;

public interface IVehicleTelemetryCsvParser
{
    Task<IEnumerable<VehicleTelemetryRecord>> ParseAsync(
        IFormFile file,
        CancellationToken cancellationToken);
}