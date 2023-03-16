using System;
using SmartBoardWebAPI.Data.DTOs;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

namespace SmartBoardWebAPI.Data.Models
{
	public class BoardModel
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public bool Active { get; set; }

		public BoardDTO ToDTO()
		{
			var dto = new BoardDTO()
			{
				Active = this.Active,
				Id = this.Id,
				Name = this.Name
			};

			return dto;
        }
    }
}

