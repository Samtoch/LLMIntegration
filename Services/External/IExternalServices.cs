

using ChatGPT.Models.ChatGPTRequest;
using ChatGPT.Models.ChatGPTResponse;

namespace ChatGPT.Services.External
{
    public interface IExternalServices
    {
        Task<GPTResponse> GetChatMessage(string text);
    }
}
