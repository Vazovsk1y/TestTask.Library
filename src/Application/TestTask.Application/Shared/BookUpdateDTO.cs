using TestTask.Domain.Entities;

namespace TestTask.Application.Shared;

public record BookUpdateDTO(string Title, string ISBN, AuthorId AuthorId, IEnumerable<GenreId> Genres, string? Description = null);