using ATMApp.Models;
using ATMApp.Models.DTOs;

namespace ATMApp.Interfaces
{
    public interface ICardServices
    {
        public Task<Card> CreateCard(CardDTO cardDTO);
    }
}
