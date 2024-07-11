using ATMApp.Exceptions;
using ATMApp.Interfaces;
using ATMApp.Models;
using ATMApp.Models.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace ATMApp.Services
{
    public class DepositServices : IDepositServices
    {
        private readonly IRepository<int, Account> _accountRepository;
        private readonly IRepository<int, Card> _cardRepository;

        public DepositServices(IRepository<int, Account> accountRepo, IRepository<int, Card> cardRepo)
        {
            _accountRepository = accountRepo;
            _cardRepository = cardRepo;
        }

        public async Task<ResponseDTO> DepositAmount(DepositAndWithdrawalDTO depositDTO)
        {

            var cards = await _cardRepository.Get();
            var card = cards.FirstOrDefault(c => c.CardNumber == depositDTO.CardNumber);

            HMACSHA512 hMACSHA = new HMACSHA512(card.PinHashKey);

            var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(depositDTO.Pin));
            bool isPasswordSame = ComparePassword(encrypterPass, card.Pin);
            if (isPasswordSame)
            {
                var account = await _accountRepository.Get(card.AccountId);

                if (account == null)
                    throw new AccountNotFoundException();

                if (depositDTO.Amount > 20000)
                    throw new DepositAmountExceedsException();

                account.Balance += depositDTO.Amount;
                await _accountRepository.Update(account);

                var responseDTO = new ResponseDTO();
                responseDTO.CurrentBalance = account.Balance;

                return responseDTO;
            }
            throw new PinMismatchException();
        }


        private bool ComparePassword(byte[] encrypterPass, byte[] password)
        {
            for (int i = 0; i < encrypterPass.Length; i++)
            {
                if (encrypterPass[i] != password[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
