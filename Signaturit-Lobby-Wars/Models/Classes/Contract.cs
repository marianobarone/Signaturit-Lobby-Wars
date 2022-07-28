using static Signaturit_Lobby_Wars.Helpers.Utils;

namespace Signaturit_Lobby_Wars.Models.Classes
{
    public class Contract
    {
        public List<SignatureRole> Signatures { get; set; }

        public int SignaturesPoints { get; set; }

        public Contract()
        {
            Signatures = new List<SignatureRole>();
        }
    }
}
