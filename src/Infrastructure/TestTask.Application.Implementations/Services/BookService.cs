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
		var book = await _dbContext
			.Books
			.Include(e => e.Author)
			.Include(e => e.Genres)
			.ThenInclude(e => e.Genre)
			.SingleOrDefaultAsync(e => e.Id == bookId, cancellationToken);

		if (book is null)
		{
			return Response.Failure<BookDTO>(Errors.EntityWithPassedIdIsNotExists(nameof(Book)));
		}

		return book.ToDTO();
	}

	public async Task<Response<BookDTO>> GetByISBNAsync(string isbn, CancellationToken cancellationToken = default)
	{
		var book = await _dbContext
			.Books
			.Include(e => e.Author)
			.Include(e => e.Genres)
			.ThenInclude(e => e.Genre)
			.SingleOrDefaultAsync(e => e.ISBN == isbn, cancellationToken);
		if (book is null)
		{
			return Response.Failure<BookDTO>(Errors.Book.BookWithPassedISBNIsNotExists);
		}

		return book.ToDTO();
	}

	public async Task<Response<BookId>> SaveAsync(BookAddDTO addDTO, CancellationToken cancellationToken = default)
	{
		if (!await _dbContext.Authors.AnyAsync(e => e.Id == addDTO.AuthorId, cancellationToken))
		{
			return Response.Failure<BookId>(Errors.Author.AuthorWithPassedIdIsNotExists);
		}

		if (await _dbContext.Books.AnyAsync(e => e.ISBN == addDTO.ISBN, cancellationToken))
		{
			return Response.Failure<BookId>(Errors.Book.BookWithPassedISBNIsAlreadyExists);
		}

		var absentGenres = addDTO.Genres.Except(await _dbContext.Genres.Where(e => addDTO.Genres.Contains(e.Id)).Select(e => e.Id).ToListAsync(cancellationToken));
        if (absentGenres.Any())
        {
			return Response.Failure<BookId>($"Genres with [{string.Join(",", absentGenres.Select(e => e.Value))}] ids is not exists.");
        }

        var book = new Book
		{
			AuthorId = addDTO.AuthorId,
			Title = addDTO.Title,
			Description = addDTO.Description,
			ISBN = addDTO.ISBN,
		};

		book.Genres = addDTO.Genres.Select(e => new BookGenre { BookId = book.Id, GenreId = e }).ToList();

		_dbContext.Books.Add(book);
		await _dbContext.SaveChangesAsync(cancellationToken);
		return book.Id;
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

	public Task<Response> UpdateAsync(BookUpdateDTO updateDTO, CancellationToken cancellationToken = default)
	{
		throw new NotImplementedException();
	}
}
