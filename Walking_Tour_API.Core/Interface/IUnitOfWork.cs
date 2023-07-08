using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walking_Tour_API.Core.Interface.Repositories;

namespace Walking_Tour_API.Core.Interface
{
    public interface IUnitOfWork
	{
		IRegionRepository Region { get; }
		ITravelRepository Travel { get; }
		Task SaveAsync();
	}
}
