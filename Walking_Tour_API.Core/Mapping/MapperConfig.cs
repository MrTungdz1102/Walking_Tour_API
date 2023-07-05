using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walking_Tour_API.Core.Models.Domain;
using Walking_Tour_API.Core.Models.DTO.Region;

namespace Walking_Tour_API.Core.Mapping
{
	public class MapperConfig : Profile
	{
		public MapperConfig()
		{
			// chi ra 2 truong k giong nhau de map voi nhau bang cach
			// .ForMember(d => d.RegionImageUrl, opt => opt.MapFrom(s => s.ImageUrl))
			CreateMap<Region, GetRegionDTO>().ReverseMap();
			CreateMap<Region, AddRegionDTO>().ReverseMap();
			CreateMap<Region, UpdateRegionDTO>().ReverseMap();
		}
	}
}
