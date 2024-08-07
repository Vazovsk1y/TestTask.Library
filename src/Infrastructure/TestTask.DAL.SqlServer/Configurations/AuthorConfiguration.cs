﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.DAL.SqlServer.Extensions;
using TestTask.Domain.Entities;

namespace TestTask.DAL.SqlServer.Configurations;

internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
	public void Configure(EntityTypeBuilder<Author> builder)
	{
		builder.ConfigureId<Author, AuthorId>();

		builder.HasIndex(e => e.FullName).IsUnique();

		builder
			.HasMany(e => e.Books)
			.WithOne(e => e.Author)
			.HasForeignKey(e => e.AuthorId);
	}
}
