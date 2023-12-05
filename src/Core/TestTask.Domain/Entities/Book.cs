using TestTask.Domain.Common;

namespace TestTask.Domain.Entities;

public class Book : Entity<BookId>
{
	public Book() : base() { }
}


public record BookId(Guid Value) : IValueId<BookId>
{
	public static BookId Create() => new(Guid.NewGuid());
}