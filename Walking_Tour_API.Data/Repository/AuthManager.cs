using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Walking_Tour_API.Core.Interface;
using Walking_Tour_API.Core.Models.DTO.User;

namespace Walking_Tour_API.Infrastructure.Repository
{
	public class AuthManager : IAuthManager
	{
		private readonly UserManager<IdentityUser> _userManager;
		private IdentityUser _user;
		private readonly IMapper _mapper;
		public AuthManager(UserManager<IdentityUser> userManager, IMapper mapper)
		{
			_userManager = userManager;
			_mapper = mapper;
		}
		public async Task<IEnumerable<IdentityError>> CreateUserAsync(RegisterDTO registerDTO)
		{
			// su dung auto mapper de khoi tao instance cua IdentityUser, neu khong ta can tao thu cong
			// bang cach _user = new IdentityUser {}
			_user = _mapper.Map<IdentityUser>(registerDTO);
			_user.UserName = registerDTO.UserName;
			_user.Email = registerDTO.UserName;

			// truong hop user chon role khong ton tai trong db, rat it xay ra vi hien thi tren UI chi nhung role co san
			//	var invalidRoles = registerDTO.Roles.Where(r => !_roleManager.RoleExistsAsync(r).Result).ToList();
			//	if (invalidRoles.Any())
			//	{
			//		return new List<IdentityError>
			//{
			//	new IdentityError
			//	{
			//		Code = "InvalidRoles",
			//		Description = $"The following roles do not exist: {string.Join(",", invalidRoles)}"
			//	}
			//};
			//	}

			var result = await _userManager.CreateAsync(_user, registerDTO.Password);
			if (result.Succeeded)
			{
				if (registerDTO.Roles.All(string.IsNullOrEmpty))
				{
					await _userManager.AddToRoleAsync(_user, "User");
				}
				else
				{
					await _userManager.AddToRolesAsync(_user, registerDTO.Roles);
				}
			}
			return result.Errors;
		}

		public async Task<bool> LoginAsync(LoginDTO loginDTO)
		{
			bool checkPass = false;
			_user = await _userManager.FindByEmailAsync(loginDTO.UserName);
			if (_user != null)
			{
				checkPass = await _userManager.CheckPasswordAsync(_user, loginDTO.Password);
			}
			if (_user == null || checkPass == false)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
	}
}
