using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TestTask.Application.Services;
using TestTask.Domain.Entities;

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

		return NotFound(result.ErrorMessage);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetBookById(Guid id)
	{
		var result = await _bookService.GetByIdAsync(new BookId(id));
		if (result.IsSuccess)
		{
			return Ok(result.Value);
		}

		return NotFound(result.ErrorMessage);
	}


	[HttpGet("byISBN/{isbn}")]
	public async Task<IActionResult> GetBookByISBN(
		[RegularExpression(
		@"^(?:ISBN(?:-13)?:? )?(?=[0-9]{13}$|(?=(?:[0-9]+[- ]){4})[- 0-9]{17}$)97[89][- ]?[0-9]{1,5}[- ]?[0-9]+[- ]?[0-9]+[- ]?[0-9]$", 
		ErrorMessage = "Incorrect ISBN format.")] string isbn)
	{
		var result = await _bookService.GetByISBNAsync(isbn);
		if (result.IsSuccess)
		{
			return Ok(result.Value);
		}

		return NotFound(result.ErrorMessage);
	}
}
