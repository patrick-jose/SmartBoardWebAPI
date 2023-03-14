using System;
namespace SmartBoardWebAPI.Data.DTOs
{
	public class BoardDTO
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public bool Active { get; set; }
		public List<SectionDTO> Sections { get; set; }
	}
}

