using TestTask.Application.Shared;
using TestTask.Domain.Entities;

namespace TestTask.Application.Services;

public interface IBookService
{
	Task<Response<IReadOnlyCollection<BookDTO>>> GetAllAsync(CancellationToken cancellationToken = default);

	Task<Response<BookDTO>> GetByIdAsync(BookId bookId, CancellationToken cancellationToken = default);

	Task<Response<BookDTO>> GetByISBNAsync(string isbn, CancellationToken cancellationToken = default);

	Task<Response<BookId>> SaveAsync(BookAddDTO addDTO, CancellationToken cancellationToken = default);

	Task<Response> DeleteAsync(BookId bookId, CancellationToken cancellationToken = default);

	Task<Response> UpdateAsync(BookUpdateDTO updateDTO, CancellationToken cancellationToken = default);

	Task<Response> HireBooksAsync(BooksHireDTO hireDTO, CancellationToken cancellationToken = default);

	Task<Response> ReturnBooksAsync(BooksReturnDTO booksReturnDTO, CancellationToken cancellationToken = default);
}
