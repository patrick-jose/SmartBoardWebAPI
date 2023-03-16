using System;
using System.Text.Json.Serialization;

namespace SmartBoardWebAPI.Data.DTOs
{
	public class SectionDTO
	{
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonRequired]
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonRequired]
        [JsonPropertyName("active")]
        public bool Active { get; set; }
        [JsonRequired]
        [JsonPropertyName("position")]
        public long Position { get; set; }
        [JsonRequired]
        [JsonPropertyName("boardid")]
        public long BoardId { get; set; }
    }
}

