using ATMApp.Models.DTOs;

namespace ATMApp.Interfaces
{
    public interface IWithdrawalService
    {
        public Task<ResponseDTO> WithdrawAmount(DepositAndWithdrawalDTO withdrawalDTO);
        public Task<int> CheckBalance(BalanceDTO balanceDTO);
    }
}
