using Signaturit_Lobby_Wars.Models.Classes;
using static Signaturit_Lobby_Wars.Helpers.Utils;

namespace Signaturit_Lobby_Wars.Services
{
    public class Lawsuits : ILawsuits
    {
        /// <summary>
        /// Returns the crontact winner
        /// </summary>
        /// <param name="contractA"></param>
        /// <param name="contractB"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Contract GetWinner(Contract contractA, Contract contractB)
        {
            try
            {
                contractA.SignaturesPoints = GetSignaturesPoints(FilterKingSignatures(contractA.Signatures));
                contractB.SignaturesPoints = GetSignaturesPoints(FilterKingSignatures(contractB.Signatures));

                if (contractA.SignaturesPoints == contractB.SignaturesPoints)
                {
                    throw new Exception($"Error, there is no contract winner. Signatures points of both contract are equals");
                }

                return contractA.SignaturesPoints > contractB.SignaturesPoints ? contractA : contractB;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        /// <summary>
        /// Returns the signatures points sum
        /// </summary>
        /// <param name="signatures"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private int GetSignaturesPoints(List<SignatureRole> signatures)
        {
            try
            {
                int points = 0;

                foreach (SignatureRole s in signatures)
                {
                    points += (int)s;
                }

                return points;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        /// <summary>
        /// Returns filtered signatures in case there's a King and Validator signature in the contract
        /// </summary>
        /// <param name="signatures"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private List<SignatureRole> FilterKingSignatures(List<SignatureRole> signatures)
        {
            bool kingAndValidator = signatures.Contains(SignatureRole.K) && signatures.Contains(SignatureRole.V);

            try
            {
                if (kingAndValidator)
                {
                    signatures = signatures.Where(x => x != SignatureRole.V).ToList();
                }

                return signatures;
            }
            catch (Exception ex)
            {
                throw new Exception($"FilterKingSignatures -> Error while filtering signatures by King and Validator - {ex.Message}");
            }
        }
    }
}
