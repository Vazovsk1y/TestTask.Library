﻿using TestTask.Application.Contracts;
using TestTask.Domain.Entities;

namespace TestTask.Application.Services;

public interface IUserService
{
	Task<Response<UserId>> RegisterAsync(UserCredentialsDTO userDTO, CancellationToken cancellationToken = default);
}