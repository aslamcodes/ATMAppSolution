namespace ATMApp.Models
{
    public class Account
    {

        public int AccountId { get; set; }

        public decimal Balance { get; set; }

        public string AccountNumber { get; set; }
        public string AccountHolderName { get; set; }

        public IEnumerable<Card> Cards { get; set; }
    }
}
