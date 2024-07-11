namespace ATMApp.Models.DTOs
{
    public class CardDTO
    {
        public int CardId { get; set; }
        public string CardNumber { get; set; }
        public string Pin { get; set; }
        public int AccountId { get; set; }
    }
}
