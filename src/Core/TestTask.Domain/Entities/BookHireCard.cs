using TestTask.Domain.Common;

namespace TestTask.Domain.Entities;
#nullable disable

public class BookHireCard : Entity<BookHireCardId>
{
	public required DateTimeOffset BookHiredDate { get; set; }

	public ICollection<BookHireItem> Books { get; set; } = new List<BookHireItem>();

	public BookHireCard() : base() { }
}

public record BookHireCardId(Guid Value) : IValueId<BookHireCardId>
{
	public static BookHireCardId Create() => new (Guid.NewGuid());
}
