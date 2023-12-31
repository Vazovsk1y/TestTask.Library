using TestTask.Application.Contracts;

namespace TestTask.Application.Services;

public interface IBookHireService
{
	Task<Response<IReadOnlyCollection<HiredBookDTO>>> HireBooksAsync(BooksHireDTO hireDTO, CancellationToken cancellationToken = default);

	Task<Response> ReturnBooksAsync(BooksReturnDTO returnDTO, CancellationToken cancellationToken = default);
}
