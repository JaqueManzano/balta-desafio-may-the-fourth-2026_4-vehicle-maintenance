namespace AutoCareAI.Ai.Providers.Astractions
{
    public interface IPromptProvider
    {
        Task<string> GetPromptAsync(string agentName, CancellationToken cancellationToken);
    }
}
