using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walking_Tour_API.Core.Models.Domain
{
	public class Travel
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public double LengthInKm { get; set; }
		public string? WalkImageUrl { get; set; }
		public Guid DifficultyId { get; set; }
		public Guid RegionId { get; set; }


		// Navigation properties
		public Difficulty Difficulty { get; set; }
		public Region Region { get; set; }
	}
}
