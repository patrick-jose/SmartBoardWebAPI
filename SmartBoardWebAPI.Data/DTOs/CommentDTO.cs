using System;
using System.Text.Json.Serialization;

namespace SmartBoardWebAPI.Data.DTOs
{
	public class CommentDTO
	{
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonRequired]
        [JsonPropertyName("writerId")]
        public long WriterId { get; set; }
        [JsonRequired]
        [JsonPropertyName("content")]
        public string Content { get; set; }
        [JsonRequired]
        [JsonPropertyName("dateCreation")]
        public DateTime DateCreation { get; set; }
        [JsonRequired]
        [JsonPropertyName("taskId")]
        public long TaskId { get; set; }
    }
}

