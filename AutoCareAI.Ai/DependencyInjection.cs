using AutoCareAI.Ai.Agents;
using AutoCareAI.Ai.Providers.Astractions;
using AutoCareAI.Core.Agents.Abstractions;
using AutoCareAI.Core.Enums;
using AutoCareAI.Core.Models;
using Microsoft.Extensions.DependencyInjection;
using Moving.Ai.Providers;

namespace AutoCareAI.Ai;

public static class DependencyInjection
{
    public static IServiceCollection AddAgents(this IServiceCollection services)
    {
        services.AddKeyedTransient<IAgent<VehicleMaintenanceAnalysisRequest, string>,VehicleMaintenanceAgent> (AgentType.AutoCareAgent);

        services.AddKeyedTransient<IPromptProvider, FilePromptProvider>(PromptProvider.File);

        return services;
    }
}