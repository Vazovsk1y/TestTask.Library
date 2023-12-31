using TestTask.Domain.Entities;

namespace TestTask.Application.Contracts;

public record BooksReturnDTO(IEnumerable<BookId> BooksToReturn, DateTimeOffset BookReturnDate);
