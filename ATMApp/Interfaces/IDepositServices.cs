using ATMApp.Models.DTOs;

namespace ATMApp.Interfaces
{
    public interface IDepositServices
    {
        public Task<ResponseDTO> DepositAmount(DepositAndWithdrawalDTO depositDTO);
    }
}
