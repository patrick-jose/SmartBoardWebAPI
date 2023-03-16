using System;
using SmartBoardWebAPI.Data.DTOs;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Data.Models
{
	public class CommentModel
	{
		public long Id { get; set; }
		public long TaskId { get; set; }
		public long WriterId { get; set; }
		public string Content { get; set; }
		public DateTime DateCreation { get; set; }

        public async Task<CommentDTO> ToDTO()
        {
            var dto = new CommentDTO()
            {
                Content = this.Content,
                DateCreation = this.DateCreation,
                WriterId = this.WriterId,
                Id = this.Id,
                TaskId = this.TaskId
            };

            return dto;
        }
    }
}

