using Microsoft.AspNetCore.Mvc;
using TestTask.Application.Services;

namespace TestTask.WebApi.Controllers;

public class AuthorsController : BaseController
{
	private readonly IAuthorService _authorService;

	public AuthorsController(IAuthorService authorService)
	{
		_authorService = authorService;
	}

	[HttpGet]
	public async Task<IActionResult> GetAllAuthors()
	{
		var result = await _authorService.GetAllAsync();
		if (result.IsSuccess)
		{
			return Ok(result.Value);
		}

		return NotFound(result.ErrorMessage);
	}
}