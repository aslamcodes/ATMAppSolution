using ATMApp.Models;
using ATMApp.Models.DTOs;
using ATMApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ATMApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositController : Controller
    {
        private readonly DepositServices _depositServices;

        public DepositController(DepositServices depositServices)
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
            catch (Exception)
            {

                throw;
            }
        }
    }
}
