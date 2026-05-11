using AutoCareAI.Core.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace AutoCareAI.Api.Services;

public class VehicleTelemetryCsvParser
    : IVehicleTelemetryCsvParser
{
    public async Task<IEnumerable<VehicleTelemetryRecord>> ParseAsync(
        IFormFile file,
        CancellationToken cancellationToken)
    {
        using var stream = file.OpenReadStream();

        using var reader = new StreamReader(stream);

        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            MissingFieldFound = null,
            HeaderValidated = null
        };

        using var csv = new CsvReader(reader, config);

        var records = csv
            .GetRecords<VehicleTelemetryRecord>()
            .ToList();

        return await Task.FromResult(records);
    }
}