using ATMApp.Exceptions;
using ATMApp.Interfaces;
using ATMApp.Models;
using ATMApp.Models.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace ATMApp.Services
{
    public class WithdrawalServices : IWithdrawalService
    {
        private readonly IRepository<int, Account> _accountRepository;
        private readonly IRepository<int, Card> _cardRepository;

        public WithdrawalServices(IRepository<int, Account> accountRepo, IRepository<int, Card> cardRepo)
        {
            _accountRepository = accountRepo;
            _cardRepository = cardRepo;
        }
        public async Task<int> CheckBalance(BalanceDTO balanceDTO)
        {
            var allCards = await _cardRepository.Get();
            var card = allCards.FirstOrDefault(c => c.CardNumber == balanceDTO.CardNumber);
            var account = await _accountRepository.Get(card.AccountId);

            if (account == null)
            {
                throw new AccountNotFoundException();
            }
            var balance = account.Balance;
            return (int)balance;
        }

        public async Task<ResponseDTO> WithdrawAmount(DepositAndWithdrawalDTO withdrawalDTO)
        {
            var allCards = await _cardRepository.Get();
            var card = allCards.FirstOrDefault(c => c.CardNumber == withdrawalDTO.CardNumber);
            var account = await _accountRepository.Get(card.AccountId);


            HMACSHA512 hMACSHA = new HMACSHA512(card.PinHashKey);

            var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(withdrawalDTO.Pin));
            bool isPasswordSame = ComparePassword(encrypterPass, card.Pin);

            if (isPasswordSame)
            {
                if (account == null)
                    throw new AccountNotFoundException();

                if (withdrawalDTO.Amount > 10000)
                    throw new WithdrawalAmountExceedsException();

                if (withdrawalDTO.Amount > account.Balance)
                    throw new InsufficientBalanceException();

                account.Balance -= withdrawalDTO.Amount;
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
