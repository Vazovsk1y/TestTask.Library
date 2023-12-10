using TestTask.Application.Services;
using TestTask.Application.Shared;

namespace TestTask.Application.Implementations.Services;

internal class BookHireService : IBookHireService
{
	public Task<Response<IReadOnlyCollection<HiredBookDTO>>> HireBooksAsync(BooksHireDTO hireDTO, CancellationToken cancellationToken = default)
	{
		throw new NotImplementedException();
	}

	public Task<Response> ReturnBooksAsync(BooksReturnDTO returnDTO, CancellationToken cancellationToken = default)
	{
		throw new NotImplementedException();
	}
}