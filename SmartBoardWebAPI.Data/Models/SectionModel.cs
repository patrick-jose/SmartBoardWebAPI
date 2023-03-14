using System;
using SmartBoardWebAPI.Data.DTOs;

namespace SmartBoardWebAPI.Data.Models
{
	public class SectionModel
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public bool Active { get; set; }
		public long BoardId { get; set; }
		public long Position { get; set; }
		public IEnumerable<TaskModel> Tasks { get; set; }

        internal SectionDTO ToDTO()
        {
            List<TaskDTO> taskDTOList = new List<TaskDTO>();

            if (this.Tasks != null)
                this.Tasks.ToList().ForEach(async x =>
                {
                    taskDTOList.Add(await x.ToDTO());
                });

            var dto = new SectionDTO()
            {
                Active = this.Active,
                Id = this.Id,
                Name = this.Name,
                Position = this.Position,
                Tasks = taskDTOList
            };

            return dto;
        }
    }
}

