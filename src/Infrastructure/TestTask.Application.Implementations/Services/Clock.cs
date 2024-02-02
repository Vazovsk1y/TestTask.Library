using TestTask.Application.Services;

namespace TestTask.Application.Implementations.Services;

internal class Clock : IClock
{
    public DateTimeOffset GetUtcNow()
    {
        return DateTimeOffset.UtcNow;
    }
}