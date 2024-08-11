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

namespace LLMIntegrations.Services.External
{
    public class ExternalServices : IExternalServices
    {
        private static Logger log = LogManager.GetCurrentClassLogger();
        private readonly IHttpService _httpService;
        private readonly LLMConfigs _config;
        public ExternalServices(IOptionsMonitor<LLMConfigs> optionsMonitor, IHttpService httpService)
        {
            _httpService = httpService;
            _config = optionsMonitor.CurrentValue;
        }

        public Task<Response> GetChatMessage(string text)
        {
            var response = new Response();
            try
            {
                var msgs = new List<Message>();
                
                foreach (var ms in msgs)
                {
                    ms.Role = _config.Role;
                    ms.Content = text;
                    msgs.Add(ms);   
                }


                var request = new Request() { Model = _config.Model, Messages = msgs };

                var item = _httpService.PostAsync(_config.BaseURL, _config.ChatEndPoint, request, _config.Key40).Result;
                response = JsonConvert.DeserializeObject<Response>(item);
            }
            catch (Exception ex)
            {
                log.Info("error with passportlogin, msg: " + ex);
            }
            return Task.FromResult(response);
        }

    }
}
