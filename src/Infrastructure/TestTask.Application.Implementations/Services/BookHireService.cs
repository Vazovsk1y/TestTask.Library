using Microsoft.EntityFrameworkCore;
using TestTask.Application.Services;
using TestTask.Application.Contracts;
using TestTask.DAL;
using TestTask.Domain.Entities;
using TestTask.Domain.Enums;

namespace TestTask.Application.Implementations.Services;

internal class BookHireService : IBookHireService
{
	private readonly TestTaskDbContext _dbContext;

	public BookHireService(TestTaskDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<Response<IReadOnlyCollection<HiredBookDTO>>> HireBooksAsync(BooksHireDTO hireDTO, CancellationToken cancellationToken = default)
	{
		if (!await _dbContext.Users.AnyAsync(e => e.Id == hireDTO.UserId, cancellationToken))
		{
			return Response.Failure<IReadOnlyCollection<HiredBookDTO>>(Errors.EntityWithPassedIdIsNotExists(nameof(User)));
		}

		var booksIds = hireDTO.Books.Select(e => e.BookId);
		var booksToHire = await _dbContext
			.Books
			.Where(e => booksIds.Contains(e.Id) && e.BookStatus == BookStatuses.Free)
			.ToListAsync(cancellationToken);

		var unavailableBooks = booksIds.Except(booksToHire.Select(e => e.Id));
		if (unavailableBooks.Any())
		{
			return Response.Failure<IReadOnlyCollection<HiredBookDTO>>($"Books with [{string.Join(",", unavailableBooks.Select(e => e.Value))}] ids is not exists or is not free."); 
		}

		var bookHireRecord = new BooksHireRecord
		{
			BooksHireDate = hireDTO.BooksHiredDate,
			UserId = hireDTO.UserId,
		};

		var result = new List<HiredBookDTO>();
        foreach (var book in hireDTO.Books)
        {
			var bookModel = booksToHire.First(e => e.Id == book.BookId);
			bookModel.BookStatus = BookStatuses.Hired;

			var hireItem = new BookHireItem
			{
				BookHireExpiryDate = hireDTO.BooksHiredDate.Add(book.HireDuration),
				BooksHireRecordId = bookHireRecord.Id,
				BookId = book.BookId,
			};

			bookHireRecord.Books.Add(hireItem);
			result.Add(new HiredBookDTO(new BookLookupDTO(bookModel.Title, bookModel.Id), hireItem.BookHireExpiryDate));
        }

		_dbContext.BooksHireRecords.Add(bookHireRecord);
		await _dbContext.SaveChangesAsync(cancellationToken);
		return result;
    }

	public async Task<Response> ReturnBooksAsync(BooksReturnDTO returnDTO, CancellationToken cancellationToken = default)
	{
		var books = await _dbContext
			.Books
			.Where(e => returnDTO.BooksToReturn.Contains(e.Id) && e.BookStatus == BookStatuses.Hired)
			.ToListAsync(cancellationToken);

		var unavailableBooks = returnDTO.BooksToReturn.Except(books.Select(e => e.Id));
		if (unavailableBooks.Any())
		{
			return Response.Failure<IReadOnlyCollection<HiredBookDTO>>($"Books with [{string.Join(",", unavailableBooks.Select(e => e.Value))}] ids is not exists or is not hired.");
		}

		var hireItems = await _dbContext
			.BookHireItems
			.Where(e => returnDTO.BooksToReturn.Contains(e.BookId) && !e.IsBookReturned)
			.ToListAsync(cancellationToken);

		var unavailableHireItems = returnDTO.BooksToReturn.Except(hireItems.Select(e => e.BookId));
		if (unavailableHireItems.Any())
		{
			throw new InvalidOperationException("Appropriate hire items for passed books not found. Inconsistency detected.");
		}

        foreach (var book in books)
        {
			book.BookStatus = BookStatuses.Free;
			var hireItem = hireItems.First(e => e.BookId == book.Id);
			hireItem.BookReturnDate = returnDTO.BookReturnDate;
			hireItem.IsBookReturned = true;
        }

		await _dbContext.SaveChangesAsync(cancellationToken);
		return Response.Success();
    }
}