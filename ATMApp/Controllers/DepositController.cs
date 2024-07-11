using ATMApp.Exceptions;
using ATMApp.Interfaces;
using ATMApp.Models;
using ATMApp.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ATMApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositController : ControllerBase
    {
        private readonly IDepositServices _depositServices;

        public DepositController(IDepositServices depositServices)
        {
            _depositServices = depositServices;
        }

        [HttpPut]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<string>> Deposit([FromBody] DepositAndWithdrawalDTO deposit)
        {
            try
            {
                var result = await _depositServices.DepositAmount(deposit);

                return Ok(result);
            }
            catch (DepositAmountExceedsException e)
            {
                return BadRequest(new ErrorModel(e.Message, StatusCodes.Status400BadRequest));
            }
            catch (AccountNotFoundException e)
            {
                return NotFound(new ErrorModel(e.Message, StatusCodes.Status404NotFound));
            }
            catch (PinMismatchException e)
            {
                return BadRequest(new ErrorModel(e.Message, StatusCodes.Status400BadRequest));
            }

            catch (Exception)
            {

                throw;
            }
        }
    }
}
