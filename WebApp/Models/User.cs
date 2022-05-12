﻿using System.Text.Json.Serialization;

namespace WebApp.Models
{
    public class User
    {
        [JsonPropertyName("UserID")]
        public int? UserID { get; set; }
        [JsonPropertyName("FirstName")]
        public string? FirstName { get; set; }
        [JsonPropertyName("LastName")]
        public string? LastName { get; set; }
        [JsonPropertyName("Birthday")]
        public DateTime? Birthday { get; set; }
        [JsonPropertyName("Email")]
        public string? Email { get; set; }
        [JsonPropertyName("Country")]
        public string? Country { get; set; }
        [JsonPropertyName("Password")]
        public string? Password { get; set; }
    }
}