using System;
namespace SmartBoardWebAPI.Data.Models
{
	public class SectionModel
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public bool Active { get; set; }
		public long BoardId { get; set; }
		public long Position { get; set; }
	}
}

