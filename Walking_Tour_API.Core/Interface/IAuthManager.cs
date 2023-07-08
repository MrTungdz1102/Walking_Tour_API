using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Walking_Tour_API.Core.Models.DTO.User;

namespace Walking_Tour_API.Core.Interface
{
	public interface IAuthManager
	{
		Task<IEnumerable<IdentityError>> CreateUserAsync(RegisterDTO registerDTO);
		Task<LoginResponseDTO> LoginAsync(LoginDTO loginDTO);
		Task<string> GenerateToken();
	}
}
