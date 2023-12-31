using TestTask.Domain.Entities;

namespace TestTask.Application.Contracts;

public record BookAddDTO(string Title, string ISBN, AuthorId AuthorId, IEnumerable<GenreId> Genres, string? Description = null);
