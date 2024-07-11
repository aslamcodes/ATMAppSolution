using ATMApp.Interfaces;
using ATMApp.Models;
using ATMApp.Models.DTOs;

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
            var account = await _accountRepository.Get(balanceDTO.CardNumber);
            if (account == null)
            {
                throw new Exception("Account not found");
            }
            var balance = account.Balance;
            return (int)balance;

        }

        public async Task<ResponseDTO> WithdrawAmount(DepositAndWithdrawalDTO withdrawalDTO)
        {
            var account = await _accountRepository.Get(withdrawalDTO.CardNumber);
            if (account == null)
                throw new Exception("Account not found");

            if (withdrawalDTO.Amount > 10000)
                throw new Exception("Withdrawal amount exceeds limit");

            if (withdrawalDTO.Amount > account.Balance)
                throw new Exception("Insufficient funds");

            account.Balance -= withdrawalDTO.Amount;
            await _accountRepository.Update(account);

            var responseDTO = new ResponseDTO();
            responseDTO.CurrentBalance = account.Balance;

            return responseDTO;
        }
    }
}
