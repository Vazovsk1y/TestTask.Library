using System.ComponentModel.DataAnnotations;

namespace TestTask.WebApi.Validation;

public class NotEmptyGuidAttribute : ValidationAttribute
{
	protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
	{
		if (value is Guid guid)
		{
			return guid == Guid.Empty ? new ValidationResult($"{validationContext.MemberName} must be not empty guid value.") : ValidationResult.Success;
		}

		if (value is IEnumerable<Guid> guids)
		{
			return guids.Any(e => e == Guid.Empty) ? new ValidationResult($"{validationContext.MemberName} contains empty guids.") : ValidationResult.Success;
		}

		return ValidationResult.Success;
	}
}
