using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TestTask.Application.Services;
using TestTask.Application.Contracts;

namespace TestTask.WebApi.Controllers;

public class GenresController : BaseController
{
	private readonly IGenreService _genreService;

	public GenresController(IGenreService genreService)
	{
		_genreService = genreService;
	}

	[HttpGet]
	[SwaggerOperation(Summary = "Get all genres.", Description = "Get a collection of all genres.")]
	[SwaggerResponse(200, "Returns a collection of GenreInfo.", typeof(IReadOnlyCollection<GenreInfo>))]
	[SwaggerResponse(401, AppConstants.SwaggerConstants.UnauthorizedMessage)]
	[SwaggerResponse(400, AppConstants.SwaggerConstants.InvalidRequestMessage)]
	[SwaggerResponse(500, AppConstants.SwaggerConstants.InternalServerError)]
	public async Task<IActionResult> GetAllGenres()
	{
		var result = await _genreService.GetAllAsync();
		if (result.IsSuccess)
		{
			return Ok(result.Value);
		}

		return BadRequest(result.ErrorMessage);
	}
}