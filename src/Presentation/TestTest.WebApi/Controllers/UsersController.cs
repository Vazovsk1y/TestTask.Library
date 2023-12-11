using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TestTask.Application.Services;
using TestTask.Application.Shared;

namespace TestTest.WebApi.Controllers;

public class UsersController : BaseController
{
	private readonly IUserService _userService;

	public UsersController(IUserService userService)
	{
		_userService = userService;
	}

	[HttpPost("sign-up")]
	public async Task<IActionResult> RegisterUser(UserRegisterModel user)
	{
		var result = await _userService.RegisterAsync(new UserRegisterDTO(user.Email, user.Password));
		if (result.IsSuccess)
		{
			return Ok("User was successfully registered.");
		}

		return BadRequest(result.ErrorMessage);
	}
}

public class UserRegisterModel
{
	[Required]
	[EmailAddress]
	public string Email { get; set; } = null!;

	[Required]
	public string Password { get; set; } = null!;
}