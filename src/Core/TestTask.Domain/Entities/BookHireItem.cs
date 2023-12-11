namespace TestTask.Domain.Entities;

#nullable disable
public class BookHireItem
{
	public required BooksHireRecordId BookHireRecordId { get; set; }

	public required BookId BookId { get; set; }

	public required DateTimeOffset BookHireExpiryDate { get; set; }

	public bool IsBookReturned { get; set; }

	public DateTimeOffset? BookReturnDate { get; set; }

	public BooksHireRecord BookHireRecord { get; set; }

	public Book Book { get; set; }	
}