using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walking_Tour_API.Infrastructure.Exception
{
	public class BadRequestException : ApplicationException
	{
		public BadRequestException(string message) : base(message)
		{

		}
	}
}
