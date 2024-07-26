using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TestTask.Application.Services;
using TestTask.DAL.SqlServer;
using TestTask.Domain.Enums;

namespace TestTask.Application.Implementations.Services;

internal class BookStatusUpdateBackgroudService : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly TimeSpan _interval = TimeSpan.FromHours(24);
    private readonly ILogger _logger;

    public BookStatusUpdateBackgroudService(IServiceScopeFactory serviceScopeFactory, ILogger<BookStatusUpdateBackgroudService> logger)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("{ServiceName} started at {UtcNow}.", nameof(BookStatusUpdateBackgroudService), DateTimeOffset.UtcNow);

        using var timer = new PeriodicTimer(_interval);

        while(!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var clock = scope.ServiceProvider.GetRequiredService<IClock>();
            var dbContext = scope.ServiceProvider.GetRequiredService<TestTaskDbContext>();

            using var transaction = dbContext.Database.BeginTransaction();
            try
            {
                var currentDate = clock.GetUtcNow();
                int updatedBooksCount = await dbContext
                    .BookHireItems
                    .Where(e => e.Book.BookStatus == BookStatuses.Hired && currentDate > e.BookHireExpiryDate)
                    .Select(e => e.Book)
                    .ExecuteUpdateAsync(setters => setters.SetProperty(e => e.BookStatus, BookStatuses.Missed), stoppingToken);

                transaction.Commit();
                _logger.LogInformation("{updatedBooksCount} books updated. Transaction commited.", updatedBooksCount);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                _logger.LogError(ex, "Book status updating failed at {UtcNow}. Transaction rollbacked.", clock.GetUtcNow());
            }
        }

        _logger.LogInformation("{ServiceName} stopped at {UtcNow}.", nameof(BookStatusUpdateBackgroudService), DateTimeOffset.UtcNow);
    }
}
