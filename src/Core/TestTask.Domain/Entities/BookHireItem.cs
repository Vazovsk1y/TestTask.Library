namespace TestTask.Domain.Entities;

#nullable disable
public class BookHireItem
{
	public required BookHireInfoId BookHireInfoId { get; set; }

	public required BookId BookId { get; set; }

	public required DateTimeOffset BookHireExpiryDate { get; set; }

	public BookHireInfo BookHireInfo { get; set; }

	public Book Book { get; set; }	
}