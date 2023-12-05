using TestTask.Domain.Common;

namespace TestTask.Domain.Entities;

public class Author : Entity<AuthorId>
{
	public required string FullName { get; set; }

	public ICollection<Book> Books { get; set; } = new List<Book>();

	public Author() : base() { }
}

public record AuthorId(Guid Value) : IValueId<AuthorId>
{
	public static AuthorId Create() => new(Guid.NewGuid());
}
