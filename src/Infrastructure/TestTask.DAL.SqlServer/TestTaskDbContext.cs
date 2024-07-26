using Microsoft.EntityFrameworkCore;
using TestTask.DAL.SqlServer.Configurations;
using TestTask.DAL.SqlServer.Extensions;
using TestTask.Domain.Entities;

namespace TestTask.DAL.SqlServer;

public class TestTaskDbContext : DbContext
{
	public DbSet<Book> Books { get; init; }

	public DbSet<Author> Authors { get; init; }

	public DbSet<Genre> Genres { get; init; }

	public DbSet<BookGenre> BooksGenres { get; init; }

	public DbSet<BooksHireRecord> BooksHireRecords { get; init; }

	public DbSet<BookHireItem> BookHireItems { get; init; }

	public DbSet<User> Users { get; init; }

	public TestTaskDbContext(DbContextOptions options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthorConfiguration).Assembly);
		modelBuilder.SeedData();
	}
}
