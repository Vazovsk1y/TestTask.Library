using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.Domain.Entities;

namespace TestTask.DAL.SqlServer.Configurations;

internal class BookGenreConfiguration : IEntityTypeConfiguration<BookGenre>
{
	public void Configure(EntityTypeBuilder<BookGenre> builder)
	{
		builder.HasKey(e => new { e.GenreId, e.BookId });
	}
}
