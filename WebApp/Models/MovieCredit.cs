﻿using System.Text.Json.Serialization;

namespace WebApp.Models
{
    public class MovieCredit
    {
        [JsonPropertyName("id")]
        public int ActorId { get; set; }

        [JsonPropertyName("cast")]
        public List<Movie> Movies { get; set; }
    }
}
