using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walking_Tour_API.Core.Models.Domain;

namespace Walking_Tour_API.Core.Interface.Repositories
{
	public interface IImageRepository
	{
		Task<Image> Upload(Image image);
	}
}
