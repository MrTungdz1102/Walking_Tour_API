using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walking_Tour_API.Core.Interface.Repositories;
using Walking_Tour_API.Core.Models.Domain;
using Walking_Tour_API.Infrastructure.Context;
using Walking_Tour_API.Infrastructure.Exception;

namespace Walking_Tour_API.Infrastructure.Repository
{
    public class TraveRepository : GenericRepository<Travel>, ITravelRepository
	{
		private readonly TourAPIDbContext _context;
		public TraveRepository(TourAPIDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<Travel> GetDetail(Guid id)
		{
			var travel = await _context.Travels.Include(x => x.Region).Include(x => x.Difficulty).FirstOrDefaultAsync(x => x.Id == id);
			if(travel is null)
			{
				throw new NotFoundException(typeof(Travel).Name, "Not Found With Key Provided");
			}
			return travel;
		}
	}
}
