using System.ComponentModel.DataAnnotations;

namespace TestTask.WebApi.Validation;

public class OnlyUniqueValuesOfAttribute<TEntity> : ValidationAttribute
{
	protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
	{
		if (value is IEnumerable<TEntity> entities)
		{
			var hashSet = new HashSet<TEntity>(entities);
			return hashSet.Count == entities.Count() ? ValidationResult.Success : new ValidationResult($"{validationContext.MemberName} contains duplicates.");
		}

		return ValidationResult.Success;
	}
}
