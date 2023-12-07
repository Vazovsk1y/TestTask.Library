using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.Domain.Entities;

namespace TestTask.DAL.Configurations;

internal class BookHireCardConfiguration : IEntityTypeConfiguration<BookHireCard>
{
	public void Configure(EntityTypeBuilder<BookHireCard> builder)
	{
		builder.ConfigureId<BookHireCard, BookHireCardId>();

		builder
			.HasMany(e => e.Books)
			.WithOne(e => e.BookHireCard)
			.HasForeignKey(e => e.BookHireCardId);
	}
}
