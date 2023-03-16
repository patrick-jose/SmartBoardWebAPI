using System;
using SmartBoardWebAPI.Data.DTOs;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Data.Models
{
	public class TaskModel
	{
		public long Id { get; set; }
		public long CreatorId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime DateCreation { get; set; }
        public bool Active { get; set; }
        public bool Blocked { get; set; }
        public long AssigneeId { get; set; }
        public long Position { get; set; }
        public long SectionId { get; set; }

        public async Task<TaskDTO> ToDTO()
        {
            var dto = new TaskDTO()
            {
                Active = this.Active,
                Id = this.Id,
                Name = this.Name,
                Position = this.Position,
                AssigneeId = this.AssigneeId,
                Blocked = this.Blocked,
                CreatorId = this.CreatorId,
                DateCreation = this.DateCreation,
                Description = this.Description,
                SectionId = this.SectionId
            };

            return dto;
        }
    }
}

