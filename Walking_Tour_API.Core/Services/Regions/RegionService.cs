using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walking_Tour_API.Core.Interface;
using Walking_Tour_API.Core.Interface.Repositories;
using Walking_Tour_API.Core.Interface.Services;
using Walking_Tour_API.Core.Models.Domain;
using Walking_Tour_API.Core.Models.DTO.Region;

namespace Walking_Tour_API.Core.Services.Regions
{
	public class RegionService : GenericService<Region, GetRegionDTO, AddRegionDTO, UpdateRegionDTO>, IRegionService
	{
		public RegionService(IMapper mapper, IGenericRepository<Region> repository, IUnitOfWork unit) : base(mapper, repository, unit)
		{
		}
		
	}
}
