using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TestTask.WebApi.Validators;

public class ISBNAttribute : RegularExpressionAttribute
{
	public const string ISBNpattern = @"^(?=[0-9]{13}$|(?=(?:[0-9]+[- ]){4})[- 0-9]{17}$)97[89][- ]?[0-9]{1,5}[- ]?[0-9]+[- ]?[0-9]+[- ]?[0-9]$";
	private ISBNAttribute([StringSyntax("Regex")] string pattern) : base(pattern)
	{
		ErrorMessage = "Incorrect ISBN format.";
	}

	public ISBNAttribute() : this(ISBNpattern) { }
}
