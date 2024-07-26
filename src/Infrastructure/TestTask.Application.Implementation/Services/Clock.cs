using TestTask.Application.Services;

namespace TestTask.Application.Implementation.Services;

internal class Clock : IClock
{
    public DateTimeOffset GetUtcNow()
    {
        return DateTimeOffset.UtcNow;
    }
}