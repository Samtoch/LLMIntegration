using System.Security.Principal;

namespace LLMIntegrations.Utilities
{
    public class OpenAIConfigs
    {
        public string Role { get; set; } = "";
        public string Model { get; set; } = "";
        public string BaseURL { get; set; } = "";
        public string EndPoint { get; set; } = "";
        public string Key { get; set; } = "";
        public string Key35 { get; set; } = "";
        public string Key40 { get; set; } = "";
        public string? Stream { get; set; }
    }
}
