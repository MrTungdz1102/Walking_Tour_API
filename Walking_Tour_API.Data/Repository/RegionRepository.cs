using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walking_Tour_API.Core.Interface;
using Walking_Tour_API.Core.Models.Domain;
using Walking_Tour_API.Infrastructure.Context;

namespace Walking_Tour_API.Infrastructure.Repository
{
	public class RegionRepository : GenericRepository<Region>, IRegionRepository
	{
		public RegionRepository(TourAPIDbContext context) : base(context)
		{
		}
	}
}
