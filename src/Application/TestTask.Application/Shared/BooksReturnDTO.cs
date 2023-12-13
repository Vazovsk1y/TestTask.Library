using TestTask.Domain.Entities;

namespace TestTask.Application.Shared;

public record BooksReturnDTO(IEnumerable<BookId> BooksToReturn, DateTimeOffset BookReturnDate);
