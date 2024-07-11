using ATMApp.Controllers.DTO;
using ATMApp.Exceptions;
using ATMApp.Exceptions.Account;
using ATMApp.Exceptions.Card;
using ATMApp.Interfaces;
using ATMApp.Models;
using ATMApp.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ATMApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WithDrawalController : ControllerBase
    {
        private readonly IWithdrawalService _services;
        public WithDrawalController(IWithdrawalService services)
        {
            _services = services;
        }

        [HttpPost("/balance")]
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
            catch (WithdrawalAmountExceedsException e)
            {
                return BadRequest(new ErrorModel(e.Message, StatusCodes.Status400BadRequest));
            }
            catch (InsufficientBalanceException e)
            {
                return BadRequest(new ErrorModel(e.Message, StatusCodes.Status400BadRequest));
            }
            catch (PinMismatchException e)
            {
                return BadRequest(new ErrorModel(e.Message, StatusCodes.Status400BadRequest));
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
