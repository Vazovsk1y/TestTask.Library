using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TestTask.Application.Services;
using TestTask.Application.Shared;

namespace TestTask.WebApi.Controllers;

public class UsersController : BaseController
{
	private readonly IUserService _userService;
	private readonly IAuthenticationService _authenticationService;

	public UsersController(IUserService userService, IAuthenticationService authenticationService)
	{
		_userService = userService;
		_authenticationService = authenticationService;
	}

	[HttpPost("sign-up"), AllowAnonymous]
	public async Task<IActionResult> RegisterUser(UserCredentialsModel user)
	{
		var result = await _userService.RegisterAsync(new UserCredentialsDTO(user.Email, user.Password));
		if (result.IsSuccess)
		{
			return Ok("User was successfully registered.");
		}

		return BadRequest(result.ErrorMessage);
	}

	[HttpPost("sign-in"), AllowAnonymous]
	public async Task<IActionResult> Login(UserCredentialsModel userCredentials)
	{
		var result = await _authenticationService.LoginAsync(new UserCredentialsDTO(userCredentials.Email, userCredentials.Password));
		if (result.IsSuccess)
		{
			return Ok(result.Value.Value);
		}

		return BadRequest(result.ErrorMessage);
	}
}

public class UserCredentialsModel
{
	[Required]
	[EmailAddress]
	public string Email { get; set; } = null!;

	[Required]
	public string Password { get; set; } = null!;
}