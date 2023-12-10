using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.Domain.Entities;

namespace TestTask.DAL.Configurations;

internal class BookHireRecordConfiguration : IEntityTypeConfiguration<BooksHireRecord>
{
	public void Configure(EntityTypeBuilder<BooksHireRecord> builder)
	{
		builder.ConfigureId<BooksHireRecord, BooksHireRecordId>();

		builder
			.HasMany(e => e.Books)
			.WithOne(e => e.BookHireCard)
			.HasForeignKey(e => e.BookHireCardId);
	}
}
