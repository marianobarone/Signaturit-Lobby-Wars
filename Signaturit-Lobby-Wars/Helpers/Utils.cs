using System.Text.Json.Serialization;

namespace Signaturit_Lobby_Wars.Helpers
{
    public static class Utils
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum SignatureRole
        {
            NONE = 0,
            V = 1,
            N = 2,
            K = 5
        }

        public static class ExceptionMessages
        {
            public const string SAME_POINTS = "There is no contract winner. Signatures points of both contract are equals";
            public const string FILTERING_ERROR = "Error while filtering signatures by King and Validator -";
            public const string NO_WINNER_SIGNATURE = "There are no available signatures to win the lawsuit";
            public const string EMPTIES_SIGNATURES = "There is a contract with more than one empty signature";
            public const string SAME_SIGNATURES = "Error, both contracts have the same signatures points";
        }
    }
}
