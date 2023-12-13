using TestTask.Application.Shared;
using TestTask.Domain.Entities;

namespace TestTask.Application.Implementations;

internal static class Mapper
{
	public static BookDTO ToDTO(this Book book)
	{
		return new BookDTO(
			book.Id,
			book.Title,
			book.ISBN,
			book.Description,
			new AuthorInfo(book.Author.Id, book.Author.FullName),
			book.Genres.Select(e => new GenreInfo(e.Genre.Id, e.Genre.Title)).ToList()
			);
	}
}
