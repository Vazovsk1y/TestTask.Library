using TestTask.Application.Contracts;

namespace TestTask.Application.Services;

public interface IAuthenticationService
{
	Task<Response<Token>> LoginAsync(UserCredentialsDTO user, CancellationToken cancellationToken = default);
}