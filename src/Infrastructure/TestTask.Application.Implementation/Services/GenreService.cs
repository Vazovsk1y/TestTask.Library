using Microsoft.EntityFrameworkCore;
using TestTask.Application.Services;
using TestTask.Application.Contracts;
using TestTask.DAL.SqlServer;

namespace TestTask.Application.Implementation.Services;

internal class GenreService : IGenreService
{
	private readonly TestTaskDbContext _dbContext;

	public GenreService(TestTaskDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<Response<IReadOnlyCollection<GenreInfo>>> GetAllAsync(CancellationToken cancellationToken = default)
	{
		var result = await _dbContext
			.Genres
			.AsNoTracking()
			.Select(e => new GenreInfo(e.Id, e.Title))
			.ToListAsync(cancellationToken);

		return result;
	}
}