using TestTask.Application.Shared;

namespace TestTask.Application.Services;

public interface IAuthenticationService
{
	Task<Response<Token>> LoginAsync(UserCredentialsDTO user, CancellationToken cancellationToken = default);
}