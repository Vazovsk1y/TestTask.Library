using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.DAL.SqlServer.Extensions;
using TestTask.Domain.Entities;

namespace TestTask.DAL.SqlServer.Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.ConfigureId<User, UserId>();

		builder.HasIndex(e => e.Email).IsUnique();

		builder
			.HasMany<BooksHireRecord>()
			.WithOne()
			.HasForeignKey(e => e.UserId);
	}
}
