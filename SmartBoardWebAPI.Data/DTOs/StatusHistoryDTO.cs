using System;
using System.Text.Json.Serialization;

namespace SmartBoardWebAPI.Data.DTOs
{
	public class StatusHistoryDTO
	{
        [JsonRequired]
        [JsonPropertyName("userId")]
        public long UserId { get; set; }
        [JsonRequired]
        [JsonPropertyName("previousSectionId")]
        public long PreviousSectionId { get; set; }
        [JsonRequired]
        [JsonPropertyName("actualSectionId")]
        public long ActualSectionId { get; set; }
        [JsonRequired]
        [JsonPropertyName("dateModified")]
        public DateTime DateModified { get; set; }
        [JsonRequired]
        [JsonPropertyName("taskId")]
        public long TaskId { get; set; }
    }
}

