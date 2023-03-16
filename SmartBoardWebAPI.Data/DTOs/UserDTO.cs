using System;
using System.Text.Json.Serialization;

namespace SmartBoardWebAPI.Data.DTOs
{
	public class UserDTO
	{
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonRequired]
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonRequired]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}

