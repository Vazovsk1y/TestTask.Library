using TestTask.Domain.Common;

namespace TestTask.Domain.Entities;
#nullable disable

public class BooksHireRecord : Entity<BooksHireRecordId>
{
	public required DateTimeOffset BooksHiredDate { get; set; }

	public ICollection<BookHireItem> Books { get; set; } = new List<BookHireItem>();

	public BooksHireRecord() : base() { }
}

public record BooksHireRecordId(Guid Value) : IValueId<BooksHireRecordId>
{
	public static BooksHireRecordId Create() => new (Guid.NewGuid());
}
