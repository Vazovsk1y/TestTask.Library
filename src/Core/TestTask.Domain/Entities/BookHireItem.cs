namespace TestTask.Domain.Entities;

#nullable disable
public class BookHireItem
{
	public required BooksHireRecordId BooksHireRecordId { get; init; }

	public required BookId BookId { get; init; }

	public required DateTimeOffset BookHireExpiryDate { get; init; }

	public bool IsBookReturned { get; set; }

	public DateTimeOffset? BookReturnDate { get; set; }

	public BooksHireRecord BooksHireRecord { get; init; }

	public Book Book { get; init; }	
}