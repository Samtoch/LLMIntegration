using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NLog;
using NLog.Fluent;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using Microsoft.Extensions.Options;
using LLMIntegrations.Utilities;
using LLMIntegrations.Services.External;
using LLMIntegrations.Models.OpenAI;
using LLMIntegrations.Services.Http;
using LLMIntegrations.Models.Llama;

namespace LLMIntegrations.Services.External
{
    public class ExternalServices : IExternalServices
    {
        private static Logger log = LogManager.GetCurrentClassLogger();
        private readonly OpenAIConfigs _configs;
        private readonly LlamaConfigs _configsLlama;
        private readonly IHttpService _httpService;
        public ExternalServices(IOptionsMonitor<OpenAIConfigs> optionsMonitor, IOptionsMonitor<LlamaConfigs> llamaOptions, IHttpService httpService)
        {
            _httpService = httpService;
            _configs = optionsMonitor.CurrentValue;
            _configsLlama = llamaOptions.CurrentValue;
        }

        public Task<Response> GetChatMessage(string text)
        {
            var response = new Response();
            try
            {
                //var msgs = new List<Message>();
                var msgs = new List<Message>() { new Message() { Role = _configs.Role, Content = text } };

                //foreach (var ms in msgs)
                //{
                //    ms.Role = _config.Role;
                //    ms.Content = text;
                //    msgs.Add(ms);   
                //}

                var request = new Request() { Model = _configs.Model, Messages = msgs };

                var item = _httpService.PostAsync(_configs.BaseURL, _configs.EndPoint, request, _configs.Key).Result;
                response = JsonConvert.DeserializeObject<Response>(item);
            }
            catch (Exception ex)
            {
                log.Info("error with passportlogin, msg: " + ex);
            }
            return Task.FromResult(response);
        }

        public Task<ResponseFromLlama> GetLlamaChat(string text)
        {
            var response = new ResponseFromLlama();
            try
            {
                string prompt = $"Return just 'Yes' or 'No' depending on if the text entered is a programming language or not. \n\n{text} c# a programming language";

                var msg = new RequestForLlama() { Model = _configsLlama.Role, Prompt = text, Stream = Convert.ToBoolean(_configsLlama.Stream) };

                var item = _httpService.PostAsync(_configsLlama.BaseURL, _configsLlama.EndPoint, msg, null).Result;
                response = JsonConvert.DeserializeObject<ResponseFromLlama>(item);
            }
            catch (Exception ex)
            {
                log.Info("error with passportlogin, msg: " + ex);
            }
            return Task.FromResult(response);
        }

    }
}
