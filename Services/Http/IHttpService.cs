namespace LLMIntegrations.Services.Http
{
    public interface IHttpService
    {
        Task<string> PostAsync(string baseUrl, string endpointurl, object body, string? token);
        Task<string> PostAsync(string baseUrl, string endpointurl, object body, string? apiKey, string? password);
        Task<string> GetAsync(string url, string? apiKey, string? password);
    }
}
