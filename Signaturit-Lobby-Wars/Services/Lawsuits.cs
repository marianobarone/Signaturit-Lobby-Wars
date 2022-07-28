using Signaturit_Lobby_Wars.Models.Classes;

namespace Signaturit_Lobby_Wars.Services
{
    public class Lawsuits : ILawsuits
    {
        public Contract GetWinner(Contract contractA, Contract contractB)
        {
            try
            {
                return new Contract();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
