using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walking_Tour_API.Core.Models.DTO.User
{
	public class LoginDTO
	{
		[Required]
		[DataType(DataType.EmailAddress)]
		public string UserName { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
