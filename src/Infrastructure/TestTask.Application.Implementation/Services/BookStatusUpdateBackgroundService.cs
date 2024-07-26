using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TestTask.Application.Services;
using TestTask.DAL.SqlServer;
using TestTask.Domain.Enums;

namespace TestTask.Application.Implementation.Services;

internal class BookStatusUpdateBackgroundService : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly TimeSpan _interval = TimeSpan.FromHours(24);
    private readonly ILogger _logger;

    public BookStatusUpdateBackgroundService(IServiceScopeFactory serviceScopeFactory, ILogger<BookStatusUpdateBackgroundService> logger)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("{ServiceName} started at {UtcNow}.", nameof(BookStatusUpdateBackgroundService), DateTimeOffset.UtcNow);

        using var timer = new PeriodicTimer(_interval);

        while(!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var clock = scope.ServiceProvider.GetRequiredService<IClock>();
            var dbContext = scope.ServiceProvider.GetRequiredService<TestTaskDbContext>();

            await using var transaction = await dbContext.Database.BeginTransactionAsync(stoppingToken);
            try
            {
                var currentDate = clock.GetUtcNow();
                int updatedBooksCount = await dbContext
                    .BookHireItems
                    .Where(e => e.Book.BookStatus == BookStatuses.Hired && currentDate > e.BookHireExpiryDate)
                    .Select(e => e.Book)
                    .ExecuteUpdateAsync(setters => setters.SetProperty(e => e.BookStatus, BookStatuses.Missed), stoppingToken);

                await transaction.CommitAsync(stoppingToken);
                _logger.LogInformation("{updatedBooksCount} books updated. Transaction commited.", updatedBooksCount);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(stoppingToken);
                _logger.LogError(ex, "Book status updating failed at {UtcNow}. Transaction rollbacked.", clock.GetUtcNow());
            }
        }

        _logger.LogInformation("{ServiceName} stopped at {UtcNow}.", nameof(BookStatusUpdateBackgroundService), DateTimeOffset.UtcNow);
    }
}
