using TestTask.Domain.Common;

namespace TestTask.Domain.Entities;
#nullable disable

public class BooksHireCard : Entity<BooksHireCardId>
{
	public required DateTimeOffset BooksHiredDate { get; set; }

	public ICollection<BookHireItem> Books { get; set; } = new List<BookHireItem>();

	public BooksHireCard() : base() { }
}

public record BooksHireCardId(Guid Value) : IValueId<BooksHireCardId>
{
	public static BooksHireCardId Create() => new (Guid.NewGuid());
}
