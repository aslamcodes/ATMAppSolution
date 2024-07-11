using ATMApp.Exceptions;
using ATMApp.Interfaces;
using ATMApp.Models;
using ATMApp.Models.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace ATMApp.Services
{
    public class CardServices : ICardServices
    {
        private readonly IRepository<int, Account> _accountRepository;
        private readonly IRepository<int, Card> _cardRepository;

        public CardServices(IRepository<int, Account> accountRepo, IRepository<int, Card> cardRepo)
        {
            _accountRepository = accountRepo;
            _cardRepository = cardRepo;
        }
        public async Task<Card> CreateCard(CardDTO cardDTO)
        {
            Card card = null;
            try
            {
                card = await MapCardDTOToCard(cardDTO);

                var exisitingCard = await _cardRepository.Get();
                var result = exisitingCard.FirstOrDefault(c => c.CardNumber == cardDTO.CardNumber);
                if (result != null)
                {
                    throw new CardAlreadyExistException();
                }

                card = await _cardRepository.Add(card);
                return card;
            }
            catch (CardAlreadyExistException ex)
            {
                throw new CardAlreadyExistException();
            }

        }

        private async Task<Card?> MapCardDTOToCard(CardDTO cardDTO)
        {
            Card card = new Card();
            card.AccountId = cardDTO.AccountId;
            card.CardNumber = cardDTO.CardNumber;

            HMACSHA512 hMACSHA = new HMACSHA512();
            card.PinHashKey = hMACSHA.Key;
            card.Pin = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(cardDTO.Pin));
            return card;

        }
    }
}
