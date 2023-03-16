using System;
using System.Text.Json.Serialization;

namespace SmartBoardWebAPI.Data.DTOs
{
	public class TaskDTO
	{       
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonRequired]
        [JsonPropertyName("creatorId")]
        public long CreatorId { get; set; }
        [JsonRequired]
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonRequired]
        [JsonPropertyName("dateCreation")]
        public DateTime DateCreation { get; set; }
        [JsonRequired]
        [JsonPropertyName("sectionId")]
        public long SectionId { get; set; }
        [JsonRequired]
        [JsonPropertyName("active")]
        public bool Active { get; set; }
        [JsonRequired]
        [JsonPropertyName("blocked")]
        public bool Blocked { get; set; }
        [JsonPropertyName("assigneeid")]
        public long? AssigneeId { get; set; }
        [JsonRequired]
        [JsonPropertyName("position")]
        public long Position { get; set; }
    }
}

