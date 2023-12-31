using System.ComponentModel.DataAnnotations;
using TestTask.WebApi.Validators;

namespace TestTask.WebApi.ViewModels;

public class BookCreateModel
{
	[Required]
	public string Title { get; set; } = null!;

	[Required]
	[ISBN]
	public string ISBN { get; set; } = null!;

	[Required]
	[NotEmptyGuid]
	public Guid AuthorId { get; set; }

	[Required]
	[NotEmptyGuid]
	[OnlyUniqueValuesOf<Guid>]
	[NotEmptyCollectionOf<Guid>]
	public IEnumerable<Guid> Genres { get; set; } = null!;

	public string? Description { get; set; }
}
