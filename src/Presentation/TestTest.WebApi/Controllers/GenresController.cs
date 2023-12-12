using Microsoft.AspNetCore.Mvc;
using TestTask.Application.Services;

namespace TestTask.WebApi.Controllers;

public class GenresController : BaseController
{
	private readonly IGenreService _genreService;

	public GenresController(IGenreService genreService)
	{
		_genreService = genreService;
	}

	[HttpGet]
	public async Task<IActionResult> GetAllGenres()
	{
		var result = await _genreService.GetAllAsync();
		if (result.IsSuccess)
		{
			return Ok(result.Value);
		}

		return NotFound(result.ErrorMessage);
	}
}