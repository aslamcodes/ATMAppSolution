using ATMApp.Controllers.DTO;
using ATMApp.Exceptions.Account;
using ATMApp.Exceptions.Card;
using ATMApp.Models;
using ATMApp.Models.DTOs;
using ATMApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ATMApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WithDrawalController : Controller
    {
        private readonly WithdrawalServices _services;
        public WithDrawalController(WithdrawalServices services)
        {
            _services = services;
        }

        [HttpGet("/balance")]
        [ProducesResponseType(typeof(BalanceResponseDto), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<BalanceResponseDto>> GetBalance([FromBody] BalanceDTO data)
        {
            try
            {

                var result = new BalanceResponseDto() { Balance = await _services.CheckBalance(data) };

                return Ok(result);
            }
            catch (CardNotFound e)
            {
                return NotFound(new ErrorModel(e.Message, StatusCodes.Status404NotFound));
            }
            catch (AccountNotFound e)
            {
                return NotFound(new ErrorModel(e.Message, StatusCodes.Status404NotFound));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<ResponseDTO>> WithDraw([FromBody] DepositAndWithdrawalDTO data)
        {
            try
            {
                var result = await _services.WithdrawAmount(data);

                return Ok(result);
            }
            catch (CardNotFound e)
            {
                return NotFound(new ErrorModel(e.Message, StatusCodes.Status404NotFound));
            }
            catch (AccountNotFound e)
            {
                return NotFound(new ErrorModel(e.Message, StatusCodes.Status404NotFound));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
