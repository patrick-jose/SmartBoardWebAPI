using System;
using SmartBoardWebAPI.Data.DTOs;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Data.Models
{
	public class StatusHistoryModel
	{
		public long UserId { get; set; }
		public long TaskId { get; set; }
		public long PreviousSectionId { get; set; }
        public long ActualSectionId { get; set; }
        public DateTime DateModified { get; set; }

        public async Task<StatusHistoryDTO> ToDTO(IUserRepository userRepository, ISectionRepository sectionRepository)
        {
            var actualSection = await sectionRepository.GetSectionByIdAsync(this.ActualSectionId, false);
            var previousSection = await sectionRepository.GetSectionByIdAsync(this.PreviousSectionId, false);
            var user = await userRepository.GetUserByIdAsync(this.UserId);

            if (actualSection == null)
                actualSection = new SectionModel();
            if (previousSection == null)
                previousSection = new SectionModel();
            if (user == null)
                user = new UserModel();

            return new StatusHistoryDTO()
            {
                ActualSection = actualSection.ToDTO(userRepository, sectionRepository),
                DateModified = this.DateModified,
                PreviousSection = previousSection.ToDTO(userRepository, sectionRepository),               
                User = user.ToDTO()
            };
        }
    }
}

