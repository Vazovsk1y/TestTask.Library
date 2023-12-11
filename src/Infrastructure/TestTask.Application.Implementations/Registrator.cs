using Microsoft.Extensions.DependencyInjection;
using TestTask.Application.Implementations.Services;
using TestTask.Application.Services;

namespace TestTask.Application.Implementations;

public static class Registrator
{
	public static IServiceCollection AddApplicationLayer(this IServiceCollection services) => services
		.AddScoped<IBookService, BookService>()
		.AddScoped<IAuthorService, AuthorService>()
		.AddScoped<IGenreService, GenreService>()
		.AddScoped<IBookHireService, BookHireService>()
		;
}
