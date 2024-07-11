namespace ATMApp.Models
{
    public class Card
    {
        public int CardId { get; set; }
        public string CardNumber { get; set; }
<<<<<<< HEAD
        public byte[] Pin { get; set; }
        public byte[] PinHashKey { get; set; }

=======
        public string Pin { get; set; }
        public string PinHashKey { get; set; }
>>>>>>> 2f0aa1d8f0161229da0e91c2b33c96a081a7f324
        public int AccountId { get; set; }

        public Account Account { get; set; }
    }
}
