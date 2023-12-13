using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.Domain.Entities;
using TestTask.Domain.Enums;

namespace TestTask.DAL.Configurations;

internal class BookConfiguration : IEntityTypeConfiguration<Book>
{
	public void Configure(EntityTypeBuilder<Book> builder)
	{
		builder.ConfigureId<Book, BookId>();

		builder.HasIndex(e => e.ISBN).IsUnique();

		builder
			.HasMany(e => e.Genres)
			.WithOne(e => e.Book)
			.HasForeignKey(e => e.BookId);

		builder
			.Property(e => e.Description)
			.IsRequired(false);

		builder
			.Property(e => e.BookStatus)
			.HasConversion(e => e.ToString(), r => Enum.Parse<BookStatus>(r));
	}
}
