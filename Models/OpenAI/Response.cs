namespace LLMIntegrations.Models.OpenAI
{
    public class Error
    {
        public string Message { get; set; }
        public string Type { get; set; }
        public string Param { get; set; }
        public string Code { get; set; }
    }

    public class Response
    {
        public Error Error { get; set; }
    }
}
