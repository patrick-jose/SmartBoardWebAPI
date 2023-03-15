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
		public IEnumerable<TaskModel> Tasks { get; set; }

        public SectionDTO ToDTO(IUserRepository userRepository, ISectionRepository sectionRepository)
        {
            List<TaskDTO> taskDTOList = new List<TaskDTO>();

            if (this.Tasks != null)
                this.Tasks.ToList().ForEach(x =>
                {
                    taskDTOList.Add(x.ToDTO(userRepository, sectionRepository).Result);
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

