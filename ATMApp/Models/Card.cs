namespace ATMApp.Models
{
    public class Card
    {
        public int CardId { get; set; }
        public string CardNumber { get; set; }
        public string Pin { get; set; }
        public string PinHashKey { get; set; }
        public decimal Balance { get; set; }

        public int AccountId { get; set; }

        public Account Account { get; set; }
    }
}
