using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.Domain.Entities;

namespace TestTask.DAL.Configurations;

internal class BookHireCardConfiguration : IEntityTypeConfiguration<BooksHireCard>
{
	public void Configure(EntityTypeBuilder<BooksHireCard> builder)
	{
		builder.ConfigureId<BooksHireCard, BooksHireCardId>();

		builder
			.HasMany(e => e.Books)
			.WithOne(e => e.BookHireCard)
			.HasForeignKey(e => e.BookHireCardId);
	}
}
