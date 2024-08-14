using LLMIntegrations.Services;
using LLMIntegrations.Services.External;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace LLMIntegrations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAIController : ControllerBase
    {
        private readonly IOpenAIService _openAIService;
        private readonly IExternalServices _extService;

        public OpenAIController(IOpenAIService openAIService, IExternalServices externalServices)
        {
            _openAIService = openAIService;
            _extService = externalServices;
        }

        [HttpGet]
        [Route("GetMessage")]
        public async Task<IActionResult> GETMessage(string input)
        {
            var response = await _openAIService.GetResponse(input);
            return Ok(response);
        }

        [HttpPost]
        [Route("openai")]
        public async Task<IActionResult> SendMessage(string request)
        {
            var response = await _extService.GetChatMessage(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("llama/chat")]
        public async Task<IActionResult> Chat(string request)
        {
            var response = await _extService.GetChatMessage(request);
            return Ok(response);
        }

    }
}
