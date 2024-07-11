using System.ComponentModel.DataAnnotations;

namespace ATMApp.Models.DTOs
{
    public class DepositAndWithdrawalDTO
    {
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string CardNumber { get; set; }
        [Required]
        public string Pin { get; set; }
    }
}
