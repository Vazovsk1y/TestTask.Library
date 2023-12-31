using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TestTask.Application.Services;
using TestTask.Application.Contracts;
using TestTask.DAL;
using TestTask.Domain.Entities;

namespace TestTask.Application.Implementations.Services;

internal class UserService : IUserService
{
	private readonly TestTaskDbContext _dbContext;

	public UserService(TestTaskDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<Response<UserId>> RegisterAsync(UserCredentialsDTO userDTO, CancellationToken cancellationToken = default)
	{
		if (await _dbContext.Users.AnyAsync(e => e.Email == userDTO.Email, cancellationToken))
		{
			return Response.Failure<UserId>(Errors.User.EmailIsAlreadyTaken);
		}

		string passwordHash = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);
		var user = new User
		{
			Email = userDTO.Email,
			PasswordHash = passwordHash
		};

		_dbContext.Users.Add(user);
		await _dbContext.SaveChangesAsync(cancellationToken);
		return user.Id;
	}
}
