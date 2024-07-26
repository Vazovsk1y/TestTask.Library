using Microsoft.EntityFrameworkCore;
using TestTask.Application.Services;
using TestTask.Application.Contracts;
using TestTask.DAL.SqlServer;

namespace TestTask.Application.Implementation.Services;

internal class AuthorService : IAuthorService
{
	private readonly TestTaskDbContext _dbContext;

	public AuthorService(TestTaskDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<Response<IReadOnlyCollection<AuthorInfo>>> GetAllAsync(CancellationToken cancellationToken = default)
	{
		var result = await _dbContext
			.Authors
			.AsNoTracking()
			.Select(e => new AuthorInfo(e.Id, e.FullName))
			.ToListAsync(cancellationToken);

		return result;
	}
}