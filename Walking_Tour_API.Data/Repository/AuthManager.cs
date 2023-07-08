using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Walking_Tour_API.Core.Interface;
using Walking_Tour_API.Core.Models.DTO.User;

namespace Walking_Tour_API.Infrastructure.Repository
{
	public class AuthManager : IAuthManager
	{
		private readonly UserManager<IdentityUser> _userManager;
		private IdentityUser _user;
		private readonly IMapper _mapper;
		private readonly IConfiguration _configuration;
		public AuthManager(UserManager<IdentityUser> userManager, IMapper mapper, IConfiguration configuration)
		{
			_userManager = userManager;
			_mapper = mapper;
			_configuration = configuration;
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

		public async Task<LoginResponseDTO> LoginAsync(LoginDTO loginDTO)
		{
			bool checkPass = false;
			_user = await _userManager.FindByEmailAsync(loginDTO.UserName);
			if (_user != null)
			{
				checkPass = await _userManager.CheckPasswordAsync(_user, loginDTO.Password);
			}
			if (_user == null || checkPass == false)
			{
				return null;
			}
			else
			{
				var token = await GenerateToken();
				return new LoginResponseDTO { Token = token };
			}
		}

		public async Task<string> GenerateToken()
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
			var roles = await _userManager.GetRolesAsync(_user);

			var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
			var userClaims = await _userManager.GetClaimsAsync(_user);

			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Sub, _user.Email),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(JwtRegisteredClaimNames.Email, _user.Email),
				new Claim("uid", _user.Id),
			}.Union(userClaims).Union(roleClaims);

			var token = new JwtSecurityToken(
				issuer: _configuration["JwtSettings:Issuer"],
				audience: _configuration["JwtSettings:Audience"],
				claims: claims,
				expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtSettings:DurationInMinutes"])),
				signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
