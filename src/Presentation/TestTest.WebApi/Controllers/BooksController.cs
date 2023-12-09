using Microsoft.AspNetCore.Mvc;
using TestTask.Application.Services;

namespace TestTest.WebApi.Controllers;

public class BooksController : BaseController
{
	private readonly IBookService _bookService;

	public BooksController(IBookService bookService)
	{
		_bookService = bookService;
	}

	[HttpGet]
	public async Task<IActionResult> GetAllBooks()
	{
		var result = await _bookService.GetAllAsync();
		if (result.IsSuccess)
		{
			return Ok(result.Value);
		}

		return NotFound();
	}
}
