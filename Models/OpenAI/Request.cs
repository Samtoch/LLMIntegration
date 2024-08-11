namespace LLMIntegrations.Models.OpenAI
{
    public class Message
    {
        public string Role { get; set; }
        public string Content { get; set; }
    }

    public class Request
    {
        public string Model { get; set; }
        public List<Message> Messages { get; set; }
    }
}
