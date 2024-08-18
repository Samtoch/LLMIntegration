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

        //[HttpGet]
        //[Route("GetMessage")]
        //public async Task<IActionResult> GETMessage(string input)
        //{
        //    var response = await _openAIService.GetResponse(input);
        //    return Ok(response);
        //}

        [HttpPost]
        [Route("Openai/Chat")]
        public async Task<IActionResult> ChatOpenai(string request)
        {
            var response = await _extService.ChatOpenai(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("Llama/Chat")]
        public async Task<IActionResult> ChatLlama(string request)
        {
            var response = await _extService.ChatLlama(request);
            string message = response.Response;
            return Ok(message);
        }

        [HttpPost]
        [Route("Llama/VerifyLanguage")]
        public async Task<IActionResult> VerifyLanguage(string request)
        {
            var response = await _extService.VerifyLanguage(request);
            string message = response.Response;
            return Ok(message);
        }
    }
}
