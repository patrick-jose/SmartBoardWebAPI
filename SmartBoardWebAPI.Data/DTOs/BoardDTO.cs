using System;
using System.Text.Json.Serialization;

namespace SmartBoardWebAPI.Data.DTOs
{
	public class BoardDTO
	{
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonRequired]
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonRequired]
        [JsonPropertyName("active")]
        public bool Active { get; set; }
	}
}

