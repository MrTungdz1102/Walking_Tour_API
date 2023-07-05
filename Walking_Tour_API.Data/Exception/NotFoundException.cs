﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walking_Tour_API.Infrastructure.Exception
{
	public class NotFoundException : ApplicationException
	{
		public NotFoundException(string name, object key) : base($"{name} with id ({key}) was not found")
		{

		}
	}
}
