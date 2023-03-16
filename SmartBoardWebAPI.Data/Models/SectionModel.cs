using System;
using SmartBoardWebAPI.Data.DTOs;
using SmartBoardWebAPI.Data.Repository;

namespace SmartBoardWebAPI.Data.Models
{
	public class SectionModel
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public bool Active { get; set; }
		public long BoardId { get; set; }
		public long Position { get; set; }

        public SectionDTO ToDTO()
        {
            var dto = new SectionDTO()
            {
                Active = this.Active,
                Id = this.Id,
                Name = this.Name,
                Position = this.Position,
                BoardId = this.BoardId
            };

            return dto;
        }
    }
}

