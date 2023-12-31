using TestTask.Domain.Entities;

namespace TestTask.Application.Contracts;

public record HiredBookDTO(BookLookupDTO Book, DateTimeOffset BookHireExpiryDate);

public record BookLookupDTO(string Title, BookId Id);
