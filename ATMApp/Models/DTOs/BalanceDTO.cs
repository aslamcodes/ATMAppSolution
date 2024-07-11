using System.ComponentModel.DataAnnotations;

namespace ATMApp.Models.DTOs
{
    public class BalanceDTO
    {
        [Required]
        public int CardNumber { get; set; }

        [Required]
        public string Pin { get; set; }
    }
}
