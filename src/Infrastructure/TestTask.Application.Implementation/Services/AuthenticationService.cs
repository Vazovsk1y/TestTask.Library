using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TestTask.Application.Services;
using TestTask.Application.Contracts;
using TestTask.DAL.SqlServer;

namespace TestTask.Application.Implementation.Services;

internal class AuthenticationService : IAuthenticationService
{
	private readonly TestTaskDbContext _dbContext;
	private readonly JwtOptions _jwtOptions;

	public AuthenticationService(TestTaskDbContext dbContext, IOptions<JwtOptions> jwtOptions)
	{
		_dbContext = dbContext;
		_jwtOptions = jwtOptions.Value;
	}

	public async Task<Response<Token>> LoginAsync(UserCredentialsDTO userDto, CancellationToken cancellationToken = default)
	{
		var user = await _dbContext.Users.FirstOrDefaultAsync(e => e.Email == userDto.Email, cancellationToken);
		if (user is null)
		{
			return Response.Failure<Token>(Errors.Auth.InvalidCredentials);
		}

		if (!BCrypt.Net.BCrypt.Verify(userDto.Password, user.PasswordHash))
		{
			return Response.Failure<Token>(Errors.Auth.InvalidCredentials);
		}

		string token = JwtTokenHelper.GenerateToken(user, _jwtOptions);

		return new Token(token);
	}
}

