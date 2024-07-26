using TestTask.Domain.Common;

namespace TestTask.Domain.Entities;
#nullable disable

public class BooksHireRecord : Entity<BooksHireRecordId>
{
	public required UserId UserId { get; init; }

	public required DateTimeOffset BooksHireDate { get; init; }

	public ICollection<BookHireItem> Books { get; init; } = new List<BookHireItem>();
}

public record BooksHireRecordId(Guid Value) : IValueId<BooksHireRecordId>
{
	public static BooksHireRecordId Create() => new (Guid.NewGuid());
}
