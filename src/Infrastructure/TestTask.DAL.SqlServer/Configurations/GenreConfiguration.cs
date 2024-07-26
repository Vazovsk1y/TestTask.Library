using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.DAL.SqlServer.Extensions;
using TestTask.Domain.Entities;

namespace TestTask.DAL.SqlServer.Configurations;

internal class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
	public void Configure(EntityTypeBuilder<Genre> builder)
	{
		builder.ConfigureId<Genre, GenreId>();

		builder.HasIndex(e => e.Title).IsUnique();

		builder
			.HasMany(e => e.Books)
			.WithOne(e => e.Genre)
			.HasForeignKey(e => e.GenreId);
	}
}
