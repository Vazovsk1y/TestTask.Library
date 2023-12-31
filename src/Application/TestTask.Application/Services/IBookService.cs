﻿using TestTask.Application.Contracts;
using TestTask.Domain.Entities;

namespace TestTask.Application.Services;

public interface IBookService
{
	Task<Response<IReadOnlyCollection<BookDTO>>> GetAllAsync(CancellationToken cancellationToken = default);

	Task<Response<BookDTO>> GetByIdAsync(BookId bookId, CancellationToken cancellationToken = default);

	Task<Response<BookDTO>> GetByISBNAsync(string isbn, CancellationToken cancellationToken = default);

	Task<Response<BookId>> SaveAsync(BookAddDTO addDTO, CancellationToken cancellationToken = default);

	Task<Response> DeleteAsync(BookId bookId, CancellationToken cancellationToken = default);

	Task<Response> UpdateAsync(BookUpdateDTO updateDTO, CancellationToken cancellationToken = default);
}
