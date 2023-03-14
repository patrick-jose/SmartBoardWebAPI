using System;
namespace SmartBoardWebAPI.Data.Models
{
	public class BoardModel
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public bool Active { get; set; }
		public IEnumerable<SectionModel> Sections { get; set; }
	}
}

