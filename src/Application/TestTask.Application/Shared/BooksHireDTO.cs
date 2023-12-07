using TestTask.Domain.Entities;

namespace TestTask.Application.Shared;

public record BooksHireDTO(IEnumerable<HiredBookDTO> Books, DateTimeOffset BooksHiredDate);

public record HiredBookDTO(BookId BookId, DateTimeOffset BookHireExpiryDate);
