using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TestTask.Application.Services;
using TestTask.Application.Shared;
using TestTask.Domain.Entities;
using TestTask.WebApi.Validation;

namespace TestTask.WebApi.Controllers;

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
	public async Task<IActionResult> GetBookById([NotEmptyGuid] Guid id)
	{
		var result = await _bookService.GetByIdAsync(new BookId(id));
		if (result.IsSuccess)
		{
			return Ok(result.Value);
		}

		return NotFound(result.ErrorMessage);
	}


	[HttpGet("byISBN/{isbn}")]
	public async Task<IActionResult> GetBookByISBN([ISBN] string isbn)
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
			return Ok($"Book with [{result.Value.Value}] id was successfully created.");
		}

		return BadRequest(result.ErrorMessage);
	}

	[HttpPut]
	public async Task<IActionResult> UpdateBook(BookUpdateModel book)
	{
		var result = await _bookService.UpdateAsync(new BookUpdateDTO(new BookId(book.BookId), book.Title, book.ISBN, new AuthorId(book.AuthorId), book.Genres.Select(e => new GenreId(e)), book.Description));
		if (result.IsSuccess)
		{
			return Ok($"Book with [{book.BookId}] id successfully updated.");
		}

		return BadRequest(result.ErrorMessage);
	}


	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteBook([NotEmptyGuid] Guid id)
	{
		var result = await _bookService.DeleteAsync(new BookId(id));
		if (result.IsSuccess)
		{
			return Ok($"Book with [{id}] was successfully deleted.");
		}

		return NotFound(result.ErrorMessage);
	}
}

public class BookCreateModel
{
	[Required]
	public string Title { get; set; } = null!;

	[Required]
	[ISBN]
	public string ISBN { get; set; } = null!;

	[Required]
	[NotEmptyGuid]
	public Guid AuthorId { get; set; }

	[Required]
	[NotEmptyGuid]
	[OnlyUniqueValuesOf<Guid>]
	[NotEmptyCollectionOf<Guid>]
	public IEnumerable<Guid> Genres { get; set; } = null!;

	public string? Description { get; set; }
}

public class BookUpdateModel
{
	[Required]
	[NotEmptyGuid]
	public Guid BookId { get; set; }

	[Required]
	public string Title { get; set; } = null!;

	[Required]
	[ISBN]
	public string ISBN { get; set; } = null!;

	[Required]
	[NotEmptyGuid]
	public Guid AuthorId { get; set; }

	[Required]
	[NotEmptyGuid]
	[OnlyUniqueValuesOf<Guid>]
	[NotEmptyCollectionOf<Guid>]
	public IEnumerable<Guid> Genres { get; set; } = null!;

	public string? Description { get; set; }
}
