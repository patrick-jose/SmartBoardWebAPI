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

        internal async Task<StatusHistoryDTO> ToDTO()
        {
            ILogWriter _log = new LogWriter();
            ISectionRepository _sectionRepository = new SectionRepository(_log);
            IUserRepository _userRepository = new UserRepository(_log);

            var actualSection = await _sectionRepository.GetSectionByIdAsync(this.ActualSectionId);
            var previousSection = await _sectionRepository.GetSectionByIdAsync(this.PreviousSectionId);
            var user = await _userRepository.GetUserByIdAsync(this.UserId);

            if (actualSection == null)
                actualSection = new SectionModel();
            if (previousSection == null)
                previousSection = new SectionModel();
            if (user == null)
                user = new UserModel();

            return new StatusHistoryDTO()
            {
                ActualSection = actualSection.ToDTO(),
                DateModified = this.DateModified,
                PreviousSection = previousSection.ToDTO(),
                User = user.ToDTO()
            };
        }
    }
}

