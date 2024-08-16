namespace LLMIntegrations.Models.Llama
{
    public class ResponseFromLlama
    {
        public string Model { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Response { get; set; }
        public bool Done { get; set; }
        public string DoneReason { get; set; }
        public List<int> Context { get; set; }
        public long TotalDuration { get; set; }
        public long LoadDuration { get; set; }
        public int PromptEvalCount { get; set; }
        public long PromptEvalDuration { get; set; }
        public int EvalCount { get; set; }
        public long EvalDuration { get; set; }
    }
}
