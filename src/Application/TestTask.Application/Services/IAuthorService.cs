using TestTask.Application.Contracts;

namespace TestTask.Application.Services;

public interface IAuthorService
{
	Task<Response<IReadOnlyCollection<AuthorInfo>>> GetAllAsync(CancellationToken cancellationToken = default);
}
