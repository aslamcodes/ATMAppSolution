using ATMApp.Interfaces;
using ATMApp.Models;
using ATMApp.Models.DTOs;

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
            var account = await _accountRepository.Get(depositDTO.CardNumber);
            if (account == null)
                throw new Exception("Account not found");

            if (depositDTO.Amount > 20000)
                throw new Exception("Deposit amount exceeds limit");

            account.Balance += depositDTO.Amount;
            await _accountRepository.Update(account);

            var responseDTO = new ResponseDTO();
            responseDTO.CurrentBalance = account.Balance;

            return responseDTO;
        }
    }
}
