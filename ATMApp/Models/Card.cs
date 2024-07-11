namespace ATMApp.Models
{
    public class Card
    {
        public int CardId { get; set; }
        public string CardNumber { get; set; }
        public byte[] Pin { get; set; }
        public byte[] PinHashKey { get; set; }

        public int AccountId { get; set; }

        public Account Account { get; set; }
    }
}
