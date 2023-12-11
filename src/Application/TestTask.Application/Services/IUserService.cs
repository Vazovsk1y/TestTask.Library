using TestTask.Application.Shared;
using TestTask.Domain.Entities;

namespace TestTask.Application.Services;

public interface IUserService
{
	Task<Response<UserId>> RegisterAsync(UserRegisterDTO userDTO, CancellationToken cancellationToken = default);
}