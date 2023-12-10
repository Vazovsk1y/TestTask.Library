using TestTask.Domain.Entities;

namespace TestTask.Application.Shared;

public record HiredBookDTO(BookId BookId, DateTimeOffset BookHireExpiryDate);
