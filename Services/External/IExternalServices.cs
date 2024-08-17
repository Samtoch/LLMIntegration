using LLMIntegrations.Models.Llama;
using LLMIntegrations.Models.OpenAI;

namespace LLMIntegrations.Services.External
{
    public interface IExternalServices
    {
        Task<Response> GetChatMessage(string text);
        Task<ResponseFromLlama> GetLlamaChat(string text);
    }
}
