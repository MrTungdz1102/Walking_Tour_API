using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walking_Tour_API.Core.Models.Domain;

namespace Walking_Tour_API.Core.Models.DTO.Travel
{
	public class DetailTravelDTO : BaseTravelDTO
	{
		public Guid Id { get; set; }
		public Difficulty? Difficulty { get; set; }
		public Domain.Region? Region { get; set; }
	}
}
