using TestTask.Domain.Common;

namespace TestTask.Domain.Entities;

public class Author : Entity<AuthorId>
{
	public required string FullName { get; init; }

	public ICollection<Book> Books { get; init; } = new List<Book>();
}

public record AuthorId(Guid Value) : IValueId<AuthorId>
{
	public static AuthorId Create() => new(Guid.NewGuid());
}
