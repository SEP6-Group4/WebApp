using System.Text.Json.Serialization;

namespace WebApp.Models
{
    public class IdCount
    {
        [JsonPropertyName("MovieID")]
        public int MovieId { get; set; }
        [JsonPropertyName("count")]
        public int count { get; set; }
    }
}
