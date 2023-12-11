using Microsoft.EntityFrameworkCore;
using TestTask.DAL.Configurations;
using TestTask.Domain.Entities;

namespace TestTask.DAL;

public class TestTaskDbContext : DbContext
{
	public DbSet<Book> Books { get; set; }

	public DbSet<Author> Authors { get; set; }

	public DbSet<Genre> Genres { get; set; }

	public DbSet<BookGenre> BooksGenres { get; set; }

	public DbSet<BooksHireRecord> BooksHireRecords { get; set; }

	public DbSet<BookHireItem> BookHireItems { get; set; }

	public DbSet<User> Users { get; set; }

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
