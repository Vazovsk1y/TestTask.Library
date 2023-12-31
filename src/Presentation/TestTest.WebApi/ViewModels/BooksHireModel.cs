using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TestTask.WebApi.Validators;

namespace TestTask.WebApi.ViewModels;

public class BooksHireModel
{
	[Required]
	[OnlyUniqueValuesOf<BookToHireModel>]
	public IEnumerable<BookToHireModel> Books { get; set; } = null!;

	[Required]
	public DateTimeOffset BooksHireDate { get; set; }

	public class BookToHireModel
	{
		[Required]
		[NotEmptyGuid]
		public Guid BookId { get; set; }

		[Required]
		[Range(1, long.MaxValue)]
		public long HireDurationHours { get; set; }

		[JsonIgnore]
		public TimeSpan HireDuration => TimeSpan.FromHours(HireDurationHours);

		public override bool Equals(object? obj)
		{
			if (obj is null || GetType() != obj.GetType())
			{
				return false;
			}

			return ((BookToHireModel)obj).BookId == BookId;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int hash = 17;
				return hash * 42 + BookId.GetHashCode();
			}
		}
	}
}
