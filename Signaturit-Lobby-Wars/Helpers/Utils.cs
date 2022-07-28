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
    }
}
