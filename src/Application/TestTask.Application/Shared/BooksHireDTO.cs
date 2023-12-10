using TestTask.Domain.Entities;

namespace TestTask.Application.Shared;

public record BooksHireDTO(IEnumerable<BookToHireDTO> Books, DateTimeOffset BooksHiredDate);

public record BookToHireDTO(BookId BookId, TimeSpan HireDuration);