namespace AutoCareAI.Core.Models;

public class VehicleMaintenanceAnalysisRequest
{
    public VehicleInformation Vehicle { get; set; } = default!;

    public IEnumerable<VehicleTelemetryRecord> Records { get; set; }
        = [];
}