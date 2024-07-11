using ATMApp.Models.DTOs;
using ATMApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ATMApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WithDrawal : Controller
    {
        private readonly WithdrawalServices _services;
        public WithDrawal(WithdrawalServices services)
        {
            _services = services;
        }

        [HttpGet("/balance")]
        public async Task<ActionResult<int>> GetBalance([FromBody] BalanceDTO data)
        {
            try
            {
                var result = await _services.CheckBalance(data);

                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public async Task<ActionResult<ResponseDTO>> WithDraw([FromBody] DepositAndWithdrawalDTO data)
        {
            try
            {
                var result = await _services.WithdrawAmount(data);

                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
