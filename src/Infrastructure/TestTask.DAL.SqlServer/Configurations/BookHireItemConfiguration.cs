using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.Domain.Entities;

namespace TestTask.DAL.SqlServer.Configurations;

internal class BookHireItemConfiguration : IEntityTypeConfiguration<BookHireItem>
{
	public void Configure(EntityTypeBuilder<BookHireItem> builder)
	{
		builder.HasKey(e => new { e.BookId, BookHireRecordId = e.BooksHireRecordId });

		builder
			.HasOne(e => e.Book)
			.WithMany()
			.HasForeignKey(e => e.BookId);
	}
}