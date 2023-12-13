using System.ComponentModel.DataAnnotations;

namespace TestTask.WebApi.ViewModels;

public class UserCredentialsModel
{
	[Required]
	[EmailAddress]
	public string Email { get; set; } = null!;

	[Required]
	public string Password { get; set; } = null!;
}