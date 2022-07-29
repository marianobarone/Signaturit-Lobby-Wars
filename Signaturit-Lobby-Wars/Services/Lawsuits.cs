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
                    throw new Exception($"There is no contract winner. Signatures points of both contract are equals");
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
                throw new Exception($"GetSignaturesPoints -> Error - {ex.Message}");
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

        /// <summary>
        /// Get the mininum signature to win the trial
        /// </summary>
        /// <param name="contractA"></param>
        /// <param name="contractB"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public SignatureRole GetMinimunSignatureToWin(Contract contractA, Contract contractB)
        {
            try
            {
                if (OnlyOneEmptySignature(contractA.Signatures, contractB.Signatures))
                {
                    SignatureRole signatureToWin = SearchSignatureToWin(contractA, contractB);

                    if (signatureToWin == SignatureRole.NONE)
                    {
                        throw new Exception($"No one of the available signatures it's availabe to win the trial");
                    }

                    return signatureToWin;
                }
                else
                {
                    throw new Exception($"There is a contract with more than one empty signature");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"GetMinimunSignatureToWin -> Error while looking for the minimun signature to win - {ex.Message}");
            }
        }

        /// <summary>
        /// Returns true/false depending if the contract has one or more empty signatures
        /// </summary>
        /// <param name="signaturesA"></param>
        /// <param name="signaturesB"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private bool OnlyOneEmptySignature(List<SignatureRole> signaturesA, List<SignatureRole> signaturesB)
        {
            try
            {
                bool onlyOneEmptySignature = signaturesA.Count(s => s == SignatureRole.NONE) > 1 || signaturesB.Count(s => s == SignatureRole.NONE) > 1 ? false : true;

                return onlyOneEmptySignature;
            }
            catch (Exception ex)
            {
                throw new Exception($"OnlyOneEmptySignature -> Error while getting number of empty contract signatures - {ex.Message}");
            }
        }

        /// <summary>
        /// Returns the minimum signature to win the trial among the available signatures 
        /// </summary>
        /// <param name="contractA"></param>
        /// <param name="contractB"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private SignatureRole SearchSignatureToWin(Contract contractA, Contract contractB)
        {
            try
            {
                SignatureRole result = SignatureRole.NONE;
                int i = 0;

                contractA.SignaturesPoints = GetSignaturesPoints(FilterKingSignatures(contractA.Signatures));
                contractB.SignaturesPoints = GetSignaturesPoints(FilterKingSignatures(contractB.Signatures));

                if (contractA.SignaturesPoints == contractB.SignaturesPoints)
                {
                    throw new Exception($"Error, both contracts have the same signatures points");
                }

                int lowerSignaturePoints = Math.Min(contractA.SignaturesPoints, contractB.SignaturesPoints);
                int higherSignaturePoints = Math.Max(contractA.SignaturesPoints, contractB.SignaturesPoints);

                SignatureRole[] signatureValues = (SignatureRole[])Enum.GetValues(typeof(SignatureRole));

                while (result == SignatureRole.NONE && i < signatureValues.Length)
                {
                    if (Convert.ToInt32(signatureValues[i]) + lowerSignaturePoints > higherSignaturePoints)
                    {
                        result = signatureValues[i];
                    }
                    i++;
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"SearchSignatureToWin -> Error while looking for signature to win - {ex.Message}");
            }
        }
    }
}
