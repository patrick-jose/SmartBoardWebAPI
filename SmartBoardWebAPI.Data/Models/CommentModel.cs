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

        internal async Task<CommentDTO> ToDTO()
        {
            ILogWriter _log = new LogWriter();
            IUserRepository _userRepository = new UserRepository(_log);

            var writer = await _userRepository.GetUserByIdAsync(this.WriterId);

            if (writer == null)
                writer = new UserModel();

            var dto = new CommentDTO()
            {
                Content = this.Content,
                DateCreation = this.DateCreation,
                Writer = writer.ToDTO(),
                Id = this.Id
            };

            return dto;
        }
    }
}

