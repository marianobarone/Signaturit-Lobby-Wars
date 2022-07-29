using Signaturit_Lobby_Wars.Models.Classes;
using static Signaturit_Lobby_Wars.Helpers.Utils;

namespace Signaturit_Lobby_Wars.Services
{
    public interface ILawsuits
    {
        Contract GetWinner(Contract contractA, Contract contractB);
        SignatureRole GetMinimunSignatureToWin(Contract contractA, Contract contractB);
    }
}
