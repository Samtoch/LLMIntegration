namespace LLMIntegrations.Models.Llama
{
    public class RequestForLlama
    {
        public string Model { get; set; }
        public string Prompt { get; set; }
        public bool Stream { get; set; }
    }
}
