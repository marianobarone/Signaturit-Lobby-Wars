using Microsoft.AspNetCore.Mvc;
using Signaturit_Lobby_Wars.Models.Classes;
using Signaturit_Lobby_Wars.Services;
using static Signaturit_Lobby_Wars.Helpers.Utils;

namespace Signaturit_Lobby_Wars.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContractController : Controller
    {
        private readonly ILawsuits _ilawsuits;
        private const string _EMPTY_SIGNATURE = "#";

        public ContractController(ILawsuits ilawsuits)
        {
            this._ilawsuits = ilawsuits;
        }

        [HttpPost("/GetContractWinner")]
        public IActionResult GetContractWinner([FromBody] ContractDTO contractsDTO)
        {
            try
            {
                Contract contractA = BuildContract(contractsDTO.ContractA);
                Contract contractB = BuildContract(contractsDTO.ContractB);

                return Ok(_ilawsuits.GetWinner(contractA, contractB));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private Contract BuildContract(List<string> contractDTOSignatures)
        {
            Contract contract = new Contract();

            try
            {
                foreach (string signature in contractDTOSignatures)
                {
                    if (signature == _EMPTY_SIGNATURE)
                    {
                        contract.Signatures.Add((SignatureRole)Enum.Parse(typeof(SignatureRole), "NONE"));
                    }
                    else
                    {
                        contract.Signatures.Add((SignatureRole)Enum.Parse(typeof(SignatureRole), signature.ToUpper()));
                    }
                }

                return contract;
            }
            catch (Exception ex)
            {
                throw new Exception($"BuildContract -> Error during building contract - {ex.Message}");
            }
        }
    }
}
