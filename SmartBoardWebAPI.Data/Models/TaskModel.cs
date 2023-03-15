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
		public IEnumerable<CommentModel> Comments { get; set; }
		public IEnumerable<StatusHistoryModel> StatusHistory { get; set; }

        public async Task<TaskDTO> ToDTO(IUserRepository userRepository, ISectionRepository sectionRepository)
        {
            List<CommentDTO> commentDTOList = new List<CommentDTO>();
            List<StatusHistoryDTO> statusHistoryDTOList = new List<StatusHistoryDTO>();
            ILogWriter _log = new LogWriter();

            if (this.Comments != null)
                this.Comments.ToList().ForEach(x =>
                {
                    commentDTOList.Add(x.ToDTO(userRepository).Result);
                });

            if (this.StatusHistory != null)
            this.StatusHistory.ToList().ForEach(x =>
            {
                statusHistoryDTOList.Add(x.ToDTO(userRepository, sectionRepository).Result);
            });

            var assignee = await userRepository.GetUserByIdAsync(this.AssigneeId);
            var creator = await userRepository.GetUserByIdAsync(this.CreatorId);

            if (assignee == null)
                assignee = new UserModel();
            if (creator == null)
                creator = new UserModel();

            var dto = new TaskDTO()
            {
                Active = this.Active,
                Id = this.Id,
                Name = this.Name,
                Position = this.Position,
                Assignee = assignee.ToDTO(),
                Blocked = this.Blocked,
                Comments = commentDTOList,
                Creator = creator.ToDTO(),
                DateCreation = this.DateCreation,
                Description = this.Description,
                StatusHistory = statusHistoryDTOList,
                SectionId = this.SectionId
            };

            return dto;
        }
    }
}

