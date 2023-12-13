namespace TestTask.Domain.Entities;

#nullable disable
public class BookGenre
{
	public required GenreId GenreId { get; init; }

	public required BookId BookId { get; init; }

	public Book Book { get; set; }

	public Genre Genre { get; set; }
}
