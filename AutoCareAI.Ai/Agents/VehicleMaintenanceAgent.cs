using AutoCareAI.Ai.Providers.Astractions;
using AutoCareAI.Core.Agents.Abstractions;
using AutoCareAI.Core.Enums;
using AutoCareAI.Core.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OllamaSharp;
using OllamaSharp.Models;

namespace AutoCareAI.Ai.Agents;

public class VehicleMaintenanceAgent
    : IAgent<VehicleMaintenanceAnalysisRequest, string>
{
    private const string AgentName = "VehicleMaintenanceAgent";

    private readonly IPromptProvider _promptProvider;
    private readonly OllamaApiClient _client;
    private readonly ILogger<VehicleMaintenanceAgent> _logger;

    private const float Temperature = 0.1f;

    public VehicleMaintenanceAgent(
        ILogger<VehicleMaintenanceAgent> logger,
        [FromKeyedServices(PromptProvider.File)]
        IPromptProvider promptProvider)
    {
        _logger = logger;
        _promptProvider = promptProvider;

        _client = OllamaClientFactory.Create();
    }

    public async Task<string> RunAsync(
        VehicleMaintenanceAnalysisRequest request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "• Gerando recomendações de manutenção do veículo...");

        var instructions = await _promptProvider
            .GetPromptAsync(AgentName, cancellationToken);

        var vehicle = request.Vehicle;

        var telemetryText = string.Join(
            Environment.NewLine + Environment.NewLine,
            request.Records.Select((record, index) => $"""
            Registro #{index + 1}

            Data da coleta:
            {record.Date:dd/MM/yyyy}

            Quilometragem atual:
            {record.Mileage} km

            Consumo médio de combustível:
            {record.FuelConsumption} km/l

            Pressão média dos pneus:
            {record.TirePressure} PSI

            Vida útil restante do óleo:
            {record.OilLifePercentage}%

            Luz de alerta do motor:
            {(record.EngineWarningLight ? "Ligada" : "Desligada")}

            Voltagem da bateria:
            {record.BatteryVoltage}V

            Desgaste das pastilhas de freio:
            {record.BrakePadWearPercentage}%
            """));

        var prompt = $"""
            {instructions}

            Veículo analisado:

            Marca:
            {vehicle.Brand}

            Modelo:
            {vehicle.Model}

            Ano:
            {vehicle.Year}

            Motor:
            {vehicle.Engine}

            Dados de telemetria:

            {telemetryText}

            Analise os dados e informe:

            - Quais manutenções devem ser realizadas
            - O nível de prioridade
            - Possíveis problemas mecânicos
            - Quais peças devem ser compradas antecipadamente
            - Possíveis riscos caso a manutenção não seja feita
            """;

        var finalResponse = string.Empty;

        await foreach (var chunk in _client.GenerateAsync(
                           new GenerateRequest
                           {
                               Prompt = prompt,
                               Options = new RequestOptions
                               {
                                   Temperature = Temperature
                               }
                           },
                           cancellationToken))
        {
            if (!string.IsNullOrWhiteSpace(chunk?.Response))
                finalResponse += chunk.Response;
        }

        _logger.LogInformation(
            "• Recomendações geradas com sucesso");

        _logger.LogInformation("---");
        _logger.LogInformation(finalResponse);
        _logger.LogInformation("---");

        return finalResponse;
    }
}