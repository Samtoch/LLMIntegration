﻿using LLMIntegrations.Utilities;
using Microsoft.Extensions.Options;
using OpenAI_API;
using OpenAI_API.Completions;

namespace LLMIntegrations.Services
{
    public class OpenAIService : IOpenAIService
    {
        private readonly LLMConfigs _configs;
        public OpenAIService(IOptionsMonitor<LLMConfigs> optionsMonitor)
        {
              _configs = optionsMonitor.CurrentValue;
        }

        public async Task<string> GetResponse(string prompt)
        {
            var openai = new OpenAIAPI(_configs.Key);
            CompletionRequest completionRequest = new CompletionRequest();
            completionRequest.Prompt = prompt;
            //completionRequest.Model = OpenAI_API.Models.Model.DavinciCode;
            completionRequest.Model = OpenAI_API.Models.Model.GPT4_Vision;
            completionRequest.MaxTokens = 10;

            var result = await openai.Completions.GetCompletion(prompt);

            //foreach (var item in completions.Completions)
            //{
            //    outputResult += item.Text;
            //}
            return result;
        }
    }
}
