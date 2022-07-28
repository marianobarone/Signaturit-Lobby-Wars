using Microsoft.AspNetCore.Mvc;
using Signaturit_Lobby_Wars.Models.Classes;
using Signaturit_Lobby_Wars.Services;

namespace Signaturit_Lobby_Wars.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContractController : Controller
    {
        private readonly ILawsuits _ilawsuits;

        public ContractController(ILawsuits ilawsuits)
        {
            this._ilawsuits = ilawsuits;
        }

        [HttpPost("/GetContractWinner")]
        public IActionResult GetContractWinner([FromBody] ContractDTO contractsDTO)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
