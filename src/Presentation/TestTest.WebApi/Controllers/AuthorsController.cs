using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TestTask.Application.Services;
using TestTask.Application.Shared;

namespace TestTask.WebApi.Controllers;

public class AuthorsController : BaseController
{
	private readonly IAuthorService _authorService;

	public AuthorsController(IAuthorService authorService)
	{
		_authorService = authorService;
	}

	[HttpGet]
	[SwaggerOperation(Summary = "Get all authors.", Description = "Get a collection of all authors.")]
	[SwaggerResponse(200, "Returns a collection of AuthorInfo.", typeof(IReadOnlyCollection<AuthorInfo>))]
	[SwaggerResponse(401, Constants.SwaggerConstants.UnauthorizedMessage)]
	[SwaggerResponse(400, Constants.SwaggerConstants.InvalidRequestMessage)]
	[SwaggerResponse(500, Constants.SwaggerConstants.InternalServerError)]
	public async Task<IActionResult> GetAllAuthors()
	{
		var result = await _authorService.GetAllAsync();
		if (result.IsSuccess)
		{
			return Ok(result.Value);
		}

		return BadRequest(result.ErrorMessage);
	}
}