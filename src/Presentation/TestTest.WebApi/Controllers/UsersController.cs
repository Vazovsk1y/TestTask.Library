using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TestTask.Application.Services;
using TestTask.Application.Shared;
using TestTask.WebApi.ViewModels;

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
	[SwaggerOperation(Summary = "Register a new user.", Description = "Register a new user.")]
	[SwaggerResponse(200, "Returns the message about successfully registration.", typeof(string))]
	[SwaggerResponse(400, Constants.SwaggerConstants.InvalidRequestMessage)]
	[SwaggerResponse(500, Constants.SwaggerConstants.InternalServerError)]
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
	[SwaggerOperation(Summary = "Login the user.", Description = "Login and receive a token for access.")]
	[SwaggerResponse(200, "Return a jwt token.", typeof(string))]
	[SwaggerResponse(400, Constants.SwaggerConstants.InvalidRequestMessage)]
	[SwaggerResponse(404, "Account not found.")]
	[SwaggerResponse(500, Constants.SwaggerConstants.InternalServerError)]
	public async Task<IActionResult> Login(UserCredentialsModel userCredentials)
	{
		var result = await _authenticationService.LoginAsync(new UserCredentialsDTO(userCredentials.Email, userCredentials.Password));
		if (result.IsSuccess)
		{
			return Ok(result.Value.Value);
		}

		return NotFound(result.ErrorMessage);
	}
}
