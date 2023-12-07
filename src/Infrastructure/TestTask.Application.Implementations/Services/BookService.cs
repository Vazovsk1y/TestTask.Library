using Microsoft.EntityFrameworkCore;
using TestTask.Application.Services;
using TestTask.Application.Shared;
using TestTask.DAL;
using TestTask.Domain.Entities;

namespace TestTask.Application.Implementations.Services;

internal class BookService : IBookService
{
	private readonly TestTaskDbContext _dbContext;

	public BookService(TestTaskDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<Response<IReadOnlyCollection<BookDTO>>> GetAllAsync(CancellationToken cancellationToken = default)
	{
		var result = await _dbContext
			.Books
			.AsNoTracking()
			.Include(e => e.Author)
			.Include(e => e.Genres)
			.ThenInclude(e => e.Genre)
			.Select(e => e.ToDTO())
			.ToListAsync(cancellationToken);

		return result;
	}

	public async Task<Response<BookDTO>> GetByIdAsync(BookId bookId, CancellationToken cancellationToken = default)
	{
		var book = await _dbContext.Books.SingleOrDefaultAsync(e => e.Id == bookId, cancellationToken);
		if (book is null)
		{
			return Response.Failure<BookDTO>(Errors.EntityWithPassedIdIsNotExists(nameof(Book)));
		}

		return book.ToDTO();
	}

	public async Task<Response<BookDTO>> GetByISBNAsync(string isbn, CancellationToken cancellationToken = default)
	{
		var book = await _dbContext.Books.SingleOrDefaultAsync(e => e.ISBN == isbn, cancellationToken);
		if (book is null)
		{
			return Response.Failure<BookDTO>(Errors.Book.BookWithPassedISBNIsNotExists);
		}

		return book.ToDTO();
	}

	public Task<Response> DeleteAsync(BookId bookId, CancellationToken cancellationToken = default)
	{
		throw new NotImplementedException();
	}

	public Task<Response> HireBooksAsync(BooksHireDTO hireDTO, CancellationToken cancellationToken = default)
	{
		throw new NotImplementedException();
	}

	public Task<Response> ReturnBooksAsync(BooksReturnDTO booksReturnDTO, CancellationToken cancellationToken = default)
	{
		throw new NotImplementedException();
	}

	public Task<Response<BookId>> SaveAsync(BookAddDTO addDTO, CancellationToken cancellationToken = default)
	{
		throw new NotImplementedException();
	}

	public Task<Response> UpdateAsync(BookUpdateDTO updateDTO, CancellationToken cancellationToken = default)
	{
		throw new NotImplementedException();
	}
}
