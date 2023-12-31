using TestTask.Application.Contracts;

namespace TestTask.Application.Services;

public interface IGenreService
{
	Task<Response<IReadOnlyCollection<GenreInfo>>> GetAllAsync(CancellationToken cancellationToken = default);
}