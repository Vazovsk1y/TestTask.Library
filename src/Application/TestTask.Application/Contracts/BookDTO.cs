﻿using TestTask.Domain.Entities;

namespace TestTask.Application.Contracts;

public record BookDTO(BookId Id, string Title, string ISBN, string? Description, AuthorInfo AuthorInfo, IReadOnlyCollection<GenreInfo> Genres);

public record AuthorInfo(AuthorId AuthorId, string FullName);

public record GenreInfo(GenreId GenreId, string Title);
