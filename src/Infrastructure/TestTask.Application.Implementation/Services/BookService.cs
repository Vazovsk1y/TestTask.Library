using Microsoft.EntityFrameworkCore;
using TestTask.Application.Services;
using TestTask.Application.Contracts;
using TestTask.DAL.SqlServer;
using TestTask.Domain.Entities;
using TestTask.Domain.Enums;

namespace TestTask.Application.Implementation.Services;

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
			return Response.Failure<BookId>(Errors.EntityWithPassedIdIsNotExists(nameof(Author)));
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
			BookStatus = BookStatuses.Free,
		};

		book.Genres = addDTO.Genres.Select(e => new BookGenre { BookId = book.Id, GenreId = e }).ToList();

		_dbContext.Books.Add(book);
		await _dbContext.SaveChangesAsync(cancellationToken);
		return book.Id;
    }

	public async Task<Response> UpdateAsync(BookUpdateDTO updateDTO, CancellationToken cancellationToken = default)
	{
		var book = await _dbContext.Books.Include(e => e.Genres).SingleOrDefaultAsync(e => e.Id == updateDTO.BookId, cancellationToken);
		if (book is null)
		{
			return Response.Failure(Errors.EntityWithPassedIdIsNotExists(nameof(Book)));
		}

		if (!await _dbContext.Authors.AnyAsync(e => e.Id == updateDTO.AuthorId, cancellationToken))
		{
			return Response.Failure(Errors.EntityWithPassedIdIsNotExists(nameof(Author)));
		}

		if (await _dbContext.Books.AnyAsync(e => e.ISBN == updateDTO.ISBN && e.Id != updateDTO.BookId, cancellationToken))
		{
			return Response.Failure<BookId>(Errors.Book.BookWithPassedISBNIsAlreadyExists);
		}

		var absentGenres = updateDTO.Genres.Except(await _dbContext.Genres.Where(e => updateDTO.Genres.Contains(e.Id)).Select(e => e.Id).ToListAsync(cancellationToken));
		if (absentGenres.Any())
		{
			return Response.Failure<BookId>($"Genres with [{string.Join(",", absentGenres.Select(e => e.Value))}] ids is not exists.");
		}

		book.Title = updateDTO.Title;
		book.Description = updateDTO.Description;
		book.AuthorId = updateDTO.AuthorId;
		book.ISBN = updateDTO.ISBN;
		book.Genres = updateDTO.Genres.Select(e => new BookGenre { BookId = book.Id, GenreId = e }).ToList();

		await _dbContext.SaveChangesAsync(cancellationToken);
		return Response.Success();
	}

	public async Task<Response> DeleteAsync(BookId bookId, CancellationToken cancellationToken = default)
	{
		var book = await _dbContext.Books.Include(e => e.Genres).SingleOrDefaultAsync(e => e.Id == bookId, cancellationToken);
		if (book is null)
		{
			return Response.Failure(Errors.EntityWithPassedIdIsNotExists(nameof(Book)));
		}

		_dbContext.Books.Remove(book);
		await _dbContext.SaveChangesAsync(cancellationToken);
		return Response.Success();
	}
}
