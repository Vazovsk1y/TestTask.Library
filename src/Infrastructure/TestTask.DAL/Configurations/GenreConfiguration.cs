using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.Domain.Entities;

namespace TestTask.DAL.Configurations;

internal class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
	public void Configure(EntityTypeBuilder<Genre> builder)
	{
		builder.ConfigureId<Genre, GenreId>();

		builder
			.HasMany(e => e.Books)
			.WithOne(e => e.Genre)
			.HasForeignKey(e => e.GenreId);
	}
}
