using TestTask.Domain.Common;

namespace TestTask.Domain.Entities;

public class User : Entity<UserId>
{
	public required string Email { get; init; }

	public required string PasswordHash { get; init; }
}

public record UserId(Guid Value) : IValueId<UserId>
{
	public static UserId Create() => new(Guid.NewGuid());
}