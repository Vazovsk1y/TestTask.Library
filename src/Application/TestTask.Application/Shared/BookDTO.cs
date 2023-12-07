using TestTask.Domain.Entities;

namespace TestTask.Application.Shared;

public record BookDTO(BookId Id, string Title, string ISBN, string? Description, AuthorInfo AuthorInfo, IReadOnlyCollection<Genre> Genres);

public record AuthorInfo(AuthorId AuthorId, string FullName);

public record GenreInfo(GenreId GenreId, string Title);
