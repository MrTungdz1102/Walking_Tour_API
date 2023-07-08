using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Walking_Tour_API.Core.Interface;
using Walking_Tour_API.Core.Models.DTO.User;
using Walking_Tour_API.Infrastructure.Repository;

namespace Walking_Tour_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly ILogger<AuthController> _logger;
		private readonly IAuthManager _auth;
		public AuthController(IAuthManager auth, ILogger<AuthController> logger)
		{
			_auth = auth;
			_logger = logger;
		}
		[HttpPost]
		[Route("Register")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
		{
			_logger.LogInformation($"Registration Attempt for {registerDTO.UserName}");
			try
			{
				var result = await _auth.CreateUserAsync(registerDTO);
				if (result.Any())
				{
					foreach (var item in result)
					{
						ModelState.AddModelError(item.Code, item.Description);
					}
					return BadRequest(ModelState);
				}

				return Ok("User was registered! Please login.");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Something Went Wrong in the {nameof(Register)}");
				return Problem($"Something went wrong in the {nameof(Register)}.", statusCode: 500);
			}
		}

		[HttpPost]
		[Route("Login")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
		{
			var result = await _auth.LoginAsync(loginDTO);
			if (result == null)
			{
				return BadRequest("Username or password incorrect");
			}
			return Ok(result);
		}
	}
}
