using TestTask.Domain.Common;

namespace TestTask.Domain.Entities;
#nullable disable

public class BookHireInfo : Entity<BookHireInfoId>
{
	public required DateTimeOffset BookHiredDate { get; set; }

	public ICollection<BookHireItem> Books { get; set; } = new List<BookHireItem>();

	public BookHireInfo() : base() { }
}

public record BookHireInfoId(Guid Value) : IValueId<BookHireInfoId>
{
	public static BookHireInfoId Create() => new (Guid.NewGuid());
}
