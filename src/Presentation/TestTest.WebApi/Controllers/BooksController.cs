using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;
using TestTask.Application.Services;
using TestTask.Application.Shared;
using TestTask.Domain.Entities;
using TestTask.WebApi.Validation;
using TestTask.WebApi.ViewModels;

namespace TestTask.WebApi.Controllers;

[ApiController]
[Route("api/books")]
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
	[SwaggerOperation(Summary = "Get all books.", Description = "Get a collection of all books.")]
	[SwaggerResponse(200, "Returns a collection of BookDTO.", typeof(IReadOnlyCollection<BookDTO>))]
	[SwaggerResponse(401, Constants.SwaggerConstants.UnauthorizedMessage)]
	[SwaggerResponse(400, Constants.SwaggerConstants.InvalidRequestMessage)]
	[SwaggerResponse(500, Constants.SwaggerConstants.InternalServerError)]
	public async Task<IActionResult> GetAllBooks()
	{
		var result = await _bookService.GetAllAsync();
		if (result.IsSuccess)
		{
			return Ok(result.Value);
		}

		return BadRequest(result.ErrorMessage);
	}

	[HttpGet("{id}")]
	[SwaggerOperation(Summary = "Get a book by Id.", Description = "Get a book by its unique identifier.")]
	[SwaggerResponse(200, "Returns a BookDTO.", typeof(BookDTO))]
	[SwaggerResponse(401, Constants.SwaggerConstants.UnauthorizedMessage)]
	[SwaggerResponse(400, Constants.SwaggerConstants.InvalidRequestMessage)]
	[SwaggerResponse(500, Constants.SwaggerConstants.InternalServerError)]
	public async Task<IActionResult> GetBookById([NotEmptyGuid] Guid id)
	{
		var result = await _bookService.GetByIdAsync(new BookId(id));
		if (result.IsSuccess)
		{
			return Ok(result.Value);
		}

		return BadRequest(result.ErrorMessage);
	}

	[HttpGet("byISBN/{isbn}")]
	[SwaggerOperation(Summary = "Get a book by ISBN.", Description = "Get a book by its ISBN.")]
	[SwaggerResponse(200, "Returns a BookDTO.", typeof(BookDTO))]
	[SwaggerResponse(401, Constants.SwaggerConstants.UnauthorizedMessage)]
	[SwaggerResponse(400, Constants.SwaggerConstants.InvalidRequestMessage)]
	[SwaggerResponse(500, Constants.SwaggerConstants.InternalServerError)]
	public async Task<IActionResult> GetBookByISBN([ISBN] string isbn)
	{
		var result = await _bookService.GetByISBNAsync(isbn);
		if (result.IsSuccess)
		{
			return Ok(result.Value);
		}

		return BadRequest(result.ErrorMessage);
	}

	[HttpPost]
	[SwaggerOperation(Summary = "Create a new book.", Description = "Create a new book with the provided details.")]
	[SwaggerResponse(200, "Returns the ID of the created book.", typeof(Guid))]
	[SwaggerResponse(401, Constants.SwaggerConstants.UnauthorizedMessage)]
	[SwaggerResponse(400, Constants.SwaggerConstants.InvalidRequestMessage)]
	[SwaggerResponse(500, Constants.SwaggerConstants.InternalServerError)]
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
	[SwaggerOperation(Summary = "Update a book.", Description = "Update an existing book with the provided details.")]
	[SwaggerResponse(200, "If the book is successfully updated.")]
	[SwaggerResponse(401, Constants.SwaggerConstants.UnauthorizedMessage)]
	[SwaggerResponse(400, Constants.SwaggerConstants.InvalidRequestMessage)]
	[SwaggerResponse(500, Constants.SwaggerConstants.InternalServerError)]
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
	[SwaggerOperation(Summary = "Delete a book by Id.", Description = "Delete a book by its unique identifier.")]
	[SwaggerResponse(200, "If the book is successfully deleted.")]
	[SwaggerResponse(401, Constants.SwaggerConstants.UnauthorizedMessage)]
	[SwaggerResponse(400, Constants.SwaggerConstants.InvalidRequestMessage)]
	[SwaggerResponse(500, Constants.SwaggerConstants.InternalServerError)]
	public async Task<IActionResult> DeleteBook([NotEmptyGuid] Guid id)
	{
		var result = await _bookService.DeleteAsync(new BookId(id));
		if (result.IsSuccess)
		{
			return Ok($"Book with [{id}] was successfully deleted.");
		}

		return BadRequest(result.ErrorMessage);
	}

	[HttpPost("hire")]
	[SwaggerOperation(Summary = "Hire books.", Description = "Hire books for a specific user with the provided details.")]
	[SwaggerResponse(200, "Returns the details of the hired books.")]
	[SwaggerResponse(401, Constants.SwaggerConstants.UnauthorizedMessage)]
	[SwaggerResponse(400, Constants.SwaggerConstants.InvalidRequestMessage)]
	[SwaggerResponse(500, Constants.SwaggerConstants.InternalServerError)]
	public async Task<IActionResult> HireBooks(BooksHireModel hireModel)
	{
		var userId = Guid.Parse(HttpContext.User.Claims.First(e => e.Type == ClaimTypes.NameIdentifier).Value);

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

	[HttpPost("return")]
	[SwaggerOperation(Summary = "Return books.", Description = "Return previously hired books with the provided details.")]
	[SwaggerResponse(200, "If the books are successfully returned.")]
	[SwaggerResponse(401, Constants.SwaggerConstants.UnauthorizedMessage)]
	[SwaggerResponse(400, Constants.SwaggerConstants.InvalidRequestMessage)]
	[SwaggerResponse(500, Constants.SwaggerConstants.InternalServerError)]
	public async Task<IActionResult> ReturnBooks(BooksReturnModel returnModel)
	{
		var result = await _bookHireService.ReturnBooksAsync(
			new BooksReturnDTO(returnModel.BooksToReturn.Select(e => new BookId(e)), returnModel.BooksReturnDate)
			);

		if (result.IsSuccess)
		{
			return Ok();
		}

		return BadRequest(result.ErrorMessage);
	}
}