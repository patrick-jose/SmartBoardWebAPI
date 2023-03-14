using System;
using SmartBoardWebAPI.Data.DTOs;

namespace SmartBoardWebAPI.Data.Models
{
	public class UserModel
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }

        public UserDTO ToDTO()
        {
            return new UserDTO()
            {
                Id = this.Id,
                Name = this.Name
            };
        }
    }
}

