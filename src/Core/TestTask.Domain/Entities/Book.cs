using TestTask.Domain.Common;
using TestTask.Domain.Enums;

namespace TestTask.Domain.Entities;

public class Book : Entity<BookId>
{
	public required string ISBN { get; set; }

	public required string Title { get; set; }

	public ICollection<BookGenre> Genres { get; set; } = new List<BookGenre>();

	public string? Description { get; set; }

	public required AuthorId AuthorId { get; set; }

	public required BookStatuses BookStatus { get; set; }

	public Author Author { get; init; } = null!;
}


public record BookId(Guid Value) : IValueId<BookId>
{
	public static BookId Create() => new(Guid.NewGuid());
}