using TestTask.Domain.Common;

namespace TestTask.Domain.Entities;

public class Genre : Entity<GenreId>
{
	public required string Title { get; init; }

	public ICollection<BookGenre> Books { get; init; } = new List<BookGenre>();
}

public record GenreId(Guid Value) : IValueId<GenreId>
{
	public static GenreId Create() => new(Guid.NewGuid());
}
