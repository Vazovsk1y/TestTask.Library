using Microsoft.Extensions.DependencyInjection;
using TestTask.Application.Implementation.Services;
using TestTask.Application.Services;

namespace TestTask.Application.Implementation;

public static class Registrator
{
	public static IServiceCollection AddApplicationLayer(this IServiceCollection services) => services
		.AddScoped<IBookService, BookService>()
		.AddScoped<IAuthorService, AuthorService>()
		.AddScoped<IGenreService, GenreService>()
		.AddScoped<IBookHireService, BookHireService>()
		.AddScoped<IUserService, UserService>()
		.AddScoped<IAuthenticationService, AuthenticationService>()
		.AddHostedService<BookStatusUpdateBackgroundService>()
		.AddScoped<IClock, Clock>()
		;
}
