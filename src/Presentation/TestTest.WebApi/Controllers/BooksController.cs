using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TestTask.Application.Services;
using TestTask.Application.Shared;
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
	public async Task<IActionResult> GetBookByISBN([RegularExpression(BookCreateModel.ISBNpattern, ErrorMessage = "Incorrect ISBN format.")] string isbn)
	{
		var result = await _bookService.GetByISBNAsync(isbn);
		if (result.IsSuccess)
		{
			return Ok(result.Value);
		}

		return NotFound(result.ErrorMessage);
	}

	[HttpPost]
	public async Task<IActionResult> CreateBook(BookCreateModel book)
	{
		var result = await _bookService.SaveAsync(new BookAddDTO(book.Title, book.ISBN, new AuthorId(book.AuthorId), book.Genres.Select(e => new GenreId(e)), book.Description));
		if (result.IsSuccess)
		{
			return Ok($"Book id is [{result.Value.Value}].");
		}

		return BadRequest(result.ErrorMessage);
	}
}

public class BookCreateModel
{
	public const string ISBNpattern = @"^(?=[0-9]{13}$|(?=(?:[0-9]+[- ]){4})[- 0-9]{17}$)97[89][- ]?[0-9]{1,5}[- ]?[0-9]+[- ]?[0-9]+[- ]?[0-9]$";

	[Required]
	public string Title { get; set; } = null!;

	[Required]
	[RegularExpression(ISBNpattern, ErrorMessage = "Incorrect ISBN format.")]
	public string ISBN { get; set; } = null!;

	[Required]
	public Guid AuthorId { get; set; }

	[Required]
	public IEnumerable<Guid> Genres { get; set; } = null!;

	public string? Description { get; set; }
}
