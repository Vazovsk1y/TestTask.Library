using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TestTask.Application.Services;
using TestTask.Application.Shared;
using TestTask.Domain.Entities;
using TestTask.WebApi.Validation;

namespace TestTask.WebApi.Controllers;

public class BooksController : BaseController
{
	private readonly IBookService _bookService;
	private readonly IBookHireService _bookHireService;

	public BooksController(IBookService bookService, IBookHireService bookHireService)
	{
		_bookService = bookService;
		_bookHireService = bookHireService;
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

	[HttpPost("hire")]
	public async Task<IActionResult> HireBook(BooksHireModel hireModel)
	{
		var userId = Guid.Parse(HttpContext.User.Claims.First(e => e.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);

		var result = await _bookHireService.HireBooksAsync(
			new BooksHireDTO
			(
				new UserId(userId), 
				hireModel.Books.Select(e => new BookToHireDTO(new BookId(e.BookId), e.HireDuration)), 
				hireModel.BooksHireDate
			));

		if (result.IsSuccess)
		{
			return Ok(result.Value);
		}

		return BadRequest(result.ErrorMessage);
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

public class BooksHireModel
{
	[Required]
	[OnlyUniqueValuesOf<BookToHireModel>]
	public IEnumerable<BookToHireModel> Books { get; set; } = null!;

	[Required]
	public DateTimeOffset BooksHireDate { get; set; }
}

public class BookToHireModel
{
	[Required]
	[NotEmptyGuid]
	public Guid BookId { get; set; }

	[Required]
	[Range(1, long.MaxValue)]
	public long HireDurationHours { get; set; }

	[JsonIgnore]
	public TimeSpan HireDuration => TimeSpan.FromHours(HireDurationHours);

	public override bool Equals(object? obj)
	{
		if (obj is null || GetType() != obj.GetType())
		{
			return false;
		}

		return ((BookToHireModel)obj).BookId == BookId;
	}

	public override int GetHashCode()
	{
		unchecked
		{
			int hash = 17;
			return hash * 42 + BookId.GetHashCode();
		}
	}
}