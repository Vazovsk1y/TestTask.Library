using System.ComponentModel.DataAnnotations;

namespace TestTask.WebApi.Validators;

public class NotEmptyCollectionOfAttribute<TEntity> : ValidationAttribute
{
	protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
	{
		if (value is IEnumerable<TEntity> entities)
		{
			return !entities.Any() ? new ValidationResult($"{validationContext.MemberName} was empty.") : ValidationResult.Success; 
		}

		return ValidationResult.Success;
	}
}