using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walking_Tour_API.Core.Interface;
using Walking_Tour_API.Core.Interface.Repositories;
using Walking_Tour_API.Infrastructure.Context;

namespace Walking_Tour_API.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
	{
		private readonly TourAPIDbContext _context;
		public IRegionRepository Region { get; private set; }
		public ITravelRepository Travel { get; private set; }
		public UnitOfWork(TourAPIDbContext context)
		{
			_context = context;
			Region = new RegionRepository(_context);
			Travel = new TraveRepository(_context);
		}

		public async Task SaveAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
