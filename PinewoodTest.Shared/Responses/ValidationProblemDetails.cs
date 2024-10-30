using System.Text.Json.Serialization;

namespace PinewoodTest.Responses
{
    public class ValidationProblemDetails
    {
        // there are some more properties, but we're only concerned with errors dictionary

        [JsonPropertyName("errors")]
        public IDictionary<string, string[]> Errors { get; init; } = new Dictionary<string, string[]>();
    }
}
