using Signaturit_Lobby_Wars.Helpers;
using Signaturit_Lobby_Wars.Models.Classes;
using Signaturit_Lobby_Wars.Services;
using Xunit;
using static Signaturit_Lobby_Wars.Helpers.Utils;

namespace Signaturit_Lobby_Wars.UnitTesting
{
    public class ContractTest
    {
        [Fact]
        public void GetWinner_ContractAWins()
        {
            Contract contractA = new Contract()
            {
                Signatures = { SignatureRole.K, SignatureRole.N }
            };
            Contract contractB = new Contract()
            {
                Signatures = { SignatureRole.N, SignatureRole.N, SignatureRole.V }
            };
            ILawsuits lawsuit = new Lawsuits();
            Contract result = lawsuit.GetWinner(contractA, contractB);

            Assert.Equal(result, contractA);
        }

        [Fact]
        public void GetWinner_ContractBWins()
        {
            Contract contractA = new Contract()
            {
                Signatures = { SignatureRole.K, SignatureRole.N }
            };
            Contract contractB = new Contract()
            {
                Signatures = { SignatureRole.N, SignatureRole.K, SignatureRole.N }
            };
            ILawsuits lawsuit = new Lawsuits();
            Contract result = lawsuit.GetWinner(contractA, contractB);

            Assert.Equal(result, contractB);
        }

        [Fact]
        public void GetWinner_TiedContractSignatures()
        {
            Contract contractA = new Contract()
            {
                Signatures = { SignatureRole.K, SignatureRole.N }
            };
            Contract contractB = new Contract()
            {
                Signatures = { SignatureRole.N, SignatureRole.K, SignatureRole.V }
            };
            ILawsuits lawsuit = new Lawsuits();

            Action act = () => lawsuit.GetWinner(contractA, contractB);
            Exception exception = Assert.Throws<Exception>(act);

            Assert.Equal(Utils.ExceptionMessages.SAME_POINTS, exception.Message);
        }

        [Fact]
        public void GetMinimunSignatureToWin_N()
        {
            Contract contractA = new Contract()
            {
                Signatures = { SignatureRole.K, SignatureRole.NONE, SignatureRole.N }
            };
            Contract contractB = new Contract()
            {
                Signatures = { SignatureRole.K, SignatureRole.N }
            };

            ILawsuits lawsuit = new Lawsuits();
            SignatureRole result = lawsuit.GetMinimunSignatureToWin(contractA, contractB);
            SignatureRole mininumExpectedSignature = SignatureRole.N;

            Assert.Equal(result, mininumExpectedSignature);
        }

        [Fact]
        public static void GetMinimunSignatureToWin_MoreThanOneEmptySignature()
        {
            Contract contractA = new Contract()
            {
                Signatures = { SignatureRole.N, SignatureRole.NONE, SignatureRole.NONE }
            };
            Contract contractB = new Contract()
            {
                Signatures = { SignatureRole.N, SignatureRole.V, SignatureRole.V }
            };

            ILawsuits lawsuit = new Lawsuits();

            Action act = () => lawsuit.GetMinimunSignatureToWin(contractA, contractB);
            Exception exception = Assert.Throws<Exception>(act);

            Assert.Equal("GetMinimunSignatureToWin -> Error while looking for the minimun signature to win - There is a contract with more than one empty signature", exception.Message);
        }

        [Fact]
        public static void GetMinimunSignatureToWin_SameContractSignatures()
        {
            Contract contractA = new Contract()
            {
                Signatures = { SignatureRole.K, SignatureRole.NONE, SignatureRole.V }
            };
            Contract contractB = new Contract()
            {
                Signatures = { SignatureRole.K, SignatureRole.NONE, SignatureRole.V }
            };

            ILawsuits lawsuit = new Lawsuits();

            Action act = () => lawsuit.GetMinimunSignatureToWin(contractA, contractB);
            Exception exception = Assert.Throws<Exception>(act);

            Assert.Equal("GetMinimunSignatureToWin -> Error while looking for the minimun signature to win - SearchSignatureToWin -> Error while looking for signature to win - Error, both contracts have the same signatures points", exception.Message);
        }

        [Fact]
        public static void GetMinimunSignatureToWin_NoMinimunSignatureFound()
        {
            Contract contractA = new Contract()
            {
                Signatures = { SignatureRole.K, SignatureRole.K, SignatureRole.V }
            };
            Contract contractB = new Contract()
            {
                Signatures = { SignatureRole.K, SignatureRole.V, SignatureRole.V }
            };

            ILawsuits lawsuit = new Lawsuits();

            Action act = () => lawsuit.GetMinimunSignatureToWin(contractA, contractB);
            Exception exception = Assert.Throws<Exception>(act);

            Assert.Equal("GetMinimunSignatureToWin -> Error while looking for the minimun signature to win - There are no available signatures to win the lawsuit", exception.Message);
        }
    }
}

