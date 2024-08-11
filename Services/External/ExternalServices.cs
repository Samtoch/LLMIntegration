using ChatGPT.Models.ChatGPTRequest;
using ChatGPT.Services.External;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NLog;
using NLog.Fluent;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using ChatGPT.Services.Http;
using Microsoft.Extensions.Options;
using ChatGPT.Utilities;
using ChatGPT.Models.ChatGPTResponse;
using OpenAI_API.Models;

namespace ChatGPT.Services.External
{
    public class ExternalServices : IExternalServices
    {
        private static Logger log = LogManager.GetCurrentClassLogger();
        private readonly IHttpService _httpService;
        private readonly ChatGPTConfigs _config;
        public ExternalServices(IOptionsMonitor<ChatGPTConfigs> optionsMonitor, IHttpService httpService)
        {
            _httpService = httpService;
            _config = optionsMonitor.CurrentValue;
        }

        public Task<GPTResponse> GetChatMessage(string text)
        {
            var response = new GPTResponse();
            try
            {
                var msgs = new List<Message>();
                
                foreach (var ms in msgs)
                {
                    ms.Role = _config.Role;
                    ms.Content = text;
                    msgs.Add(ms);   
                }


                var request = new GPTRequest() { Model = _config.Model, Messages = msgs };

                var item = _httpService.PostAsync(_config.BaseURL, _config.ChatEndPoint, request, _config.Key40).Result;
                response = JsonConvert.DeserializeObject<GPTResponse>(item);
            }
            catch (Exception ex)
            {
                log.Info("error with passportlogin, msg: " + ex);
            }
            return Task.FromResult(response);
        }

    }
}
