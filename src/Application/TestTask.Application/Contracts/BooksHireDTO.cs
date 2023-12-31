﻿using TestTask.Domain.Entities;

namespace TestTask.Application.Contracts;

public record BooksHireDTO(UserId UserId, IEnumerable<BookToHireDTO> Books, DateTimeOffset BooksHiredDate);

public record BookToHireDTO(BookId BookId, TimeSpan HireDuration);