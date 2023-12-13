using TestTask.Domain.Common;

namespace TestTask.Domain.Entities;

public class Genre : Entity<GenreId>
{
	public Genre() : base() { }

	public required string Title { get; set; }

	public ICollection<BookGenre> Books { get; set; } = new List<BookGenre>();
}

public record GenreId(Guid Value) : IValueId<GenreId>
{
	public static GenreId Create() => new(Guid.NewGuid());
}
