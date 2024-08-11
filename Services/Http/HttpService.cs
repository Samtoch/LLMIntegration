using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using System.Text;
using NLog.Fluent;
using NLog;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LLMIntegrations.Services.Http
{
    public class HttpService : IHttpService
    {
        private static Logger log = LogManager.GetCurrentClassLogger();

        public Task<string> PostAsync(string baseUrl, string endpointurl, object body, string? token)
        {
            string item = "not found";
            try
            {
                using (var _client = new HttpClient())
                {
                    if (token != "")
                    {
                        _client.DefaultRequestHeaders.Add("token", token);
                    }
                    _client.BaseAddress = new Uri(baseUrl);
                    var json = JsonConvert.SerializeObject(body);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = _client.PostAsync(endpointurl, content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var Content = response.Content.ReadAsStringAsync().Result;
                        log.Info("DetailsJson: " + Content);
                        return Task.FromResult(Content);
                    }
                    var problemDetailsJson = response.Content.ReadAsStringAsync();
                    log.Error("problemDetailsJson: " + problemDetailsJson);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error in PostAsync, Msg: " + ex);
            }
            return Task.FromResult(item);
        }

        public Task<string> PostAsync(string baseUrl, string endpointurl, object body, string? apiKey, string? password)
        {
            string item = "not found";
            try
            {
                using (var _client = new HttpClient())
                {
                    if (!string.IsNullOrEmpty(apiKey) && !string.IsNullOrEmpty(password))
                    {
                        _client.DefaultRequestHeaders.Add(apiKey, password);
                    }
                    if (!string.IsNullOrEmpty(apiKey) && string.IsNullOrEmpty(password))
                    {
                        _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + password);
                    }
                    _client.BaseAddress = new Uri(baseUrl);
                    var json = JsonConvert.SerializeObject(body);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = _client.PostAsync(endpointurl, content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var Content = response.Content.ReadAsStringAsync().Result;
                        log.Info("DetailsJson: " + Content);
                        return Task.FromResult(Content);
                    }
                    var problemDetailsJson = response.Content.ReadAsStringAsync().Result;
                    log.Error("problemDetailsJson: " + problemDetailsJson);
                    return Task.FromResult(problemDetailsJson);// TO BE REMOVED. NOT NECESSARY
                }
            }
            catch (Exception ex)
            {
                log.Error("Error in PostAsync, Msg: " + ex);
            }
            return Task.FromResult(item);
        }

        public Task<string> GetAsync(string url, string? apiKey, string? password)
        {
            string item = "not found";
            try
            {
                using (var _client = new HttpClient())
                {
                    if (!string.IsNullOrEmpty(apiKey) && !string.IsNullOrEmpty(password))
                    {
                        _client.DefaultRequestHeaders.Add(apiKey, password);                        
                    }
                    if (!string.IsNullOrEmpty(apiKey) && string.IsNullOrEmpty(password))
                    {
                        _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + password);
                    }
                    //_client.BaseAddress = new Uri(baseUrl);
                    var response = _client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var Content = response.Content.ReadAsStringAsync().Result;
                        log.Info("DetailsJson: " + Content);
                        return Task.FromResult(Content);
                    }
                    var problemDetailsJson = response.Content.ReadAsStringAsync();
                    log.Error("problemDetailsJson: " + problemDetailsJson);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error in GetAsync, Msg: " + ex);
            }
            return Task.FromResult(item);
        }
    }
}
