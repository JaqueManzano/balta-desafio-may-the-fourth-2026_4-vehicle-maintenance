namespace AutoCareAI.Api.Requests;

public class VehicleTelemetryAnalysisRequest
{
    public IFormFile File { get; set; } = default!;

    public string Brand { get; set; } = string.Empty;

    public string Model { get; set; } = string.Empty;

    public int Year { get; set; }

    public string Engine { get; set; } = string.Empty;
}