using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.DAL.SqlServer.Extensions;
using TestTask.Domain.Entities;

namespace TestTask.DAL.SqlServer.Configurations;

internal class BookHireRecordConfiguration : IEntityTypeConfiguration<BooksHireRecord>
{
	public void Configure(EntityTypeBuilder<BooksHireRecord> builder)
	{
		builder.ConfigureId<BooksHireRecord, BooksHireRecordId>();

		builder
			.HasMany(e => e.Books)
			.WithOne(e => e.BooksHireRecord)
			.HasForeignKey(e => e.BooksHireRecordId);
	}
}
