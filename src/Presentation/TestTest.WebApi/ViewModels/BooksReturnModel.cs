using System.ComponentModel.DataAnnotations;
using TestTask.WebApi.Validators;

namespace TestTask.WebApi.ViewModels;

public class BooksReturnModel
{
	[Required]
	[NotEmptyGuid]
	[OnlyUniqueValuesOf<Guid>]
	public IEnumerable<Guid> BooksToReturn { get; set; } = null!;

	[Required]
	public DateTimeOffset BooksReturnDate { get; set; }
}
