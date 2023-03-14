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
		public IEnumerable<SectionModel> Sections { get; set; }

		public BoardDTO ToDTO()
		{
			List<SectionDTO> sectionDTOList = new List<SectionDTO>();

			if (this.Sections != null)
				this.Sections.ToList().ForEach(x =>
				{
					sectionDTOList.Add(x.ToDTO());
				});

			var dto = new BoardDTO()
			{
				Active = this.Active,
				Id = this.Id,
				Name = this.Name,
				Sections = sectionDTOList
			};

			return dto;
        }
    }
}

