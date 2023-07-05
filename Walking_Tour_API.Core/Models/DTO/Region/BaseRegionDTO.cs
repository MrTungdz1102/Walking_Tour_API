using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walking_Tour_API.Core.Models.DTO.Region
{
	public abstract class BaseRegionDTO
	{
		public string Code { get; set; }

		public string Name { get; set; }

		public string? RegionImageUrl { get; set; }
	}
}
