using LLMIntegrations.Models.Llama;
using LLMIntegrations.Models.OpenAI;

namespace LLMIntegrations.Services.External
{
    public interface IExternalServices
    {
        Task<Response> ChatOpenai(string text);
        Task<ResponseFromLlama> ChatLlama(string text);
        Task<ResponseFromLlama> VerifyLanguage(string text);
    }
}
