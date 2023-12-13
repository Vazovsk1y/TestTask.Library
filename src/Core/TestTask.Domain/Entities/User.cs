using TestTask.Domain.Common;

namespace TestTask.Domain.Entities;

public class User : Entity<UserId>
{
	public required string Email { get; set; }

	public required string PasswordHash { get; set; }

	public User() : base() { }
}

public record UserId(Guid Value) : IValueId<UserId>
{
	public static UserId Create() => new(Guid.NewGuid());
}