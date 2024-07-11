using System.ComponentModel.DataAnnotations;

namespace ATMApp.Models.DTOs
{
    public class DepositAndWithdrawalDTO
    {
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public int CardNumber { get; set; }
        [Required]
        public int Pin { get; set; }
    }
}
