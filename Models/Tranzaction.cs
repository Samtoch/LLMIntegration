namespace ChatGPT.Models
{
    public class Tranzaction
    {
        public int UserId { get; set; }
        public long TransactionId { get; set; }
        public DateTime TransactionTime { get; set; }
        public long ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public int NumberOfItemsPurchased { get; set; }
        public decimal CostPerItem { get; set; }
        public string Country { get; set; }
    }
}
