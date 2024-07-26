using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TestTask.Application.Implementations.Services;
using TestTask.DAL.SqlServer;

namespace TestTask.WebApi;

public static class Extensions 
{
	public static IServiceCollection AddSwaggerWithJwtSecurity(this IServiceCollection collection)
	{
		return collection.AddSwaggerGen(swagger =>
		{
			swagger.EnableAnnotations();

			swagger.AddSecurityDefinition(AppConstants.SwaggerConstants.OpenApiSecurityScheme, new OpenApiSecurityScheme
			{
				Name = AppConstants.SwaggerConstants.OpenApiSecuritySchemeName,
				Type = SecuritySchemeType.ApiKey,
				Scheme = AppConstants.SwaggerConstants.OpenApiSecurityScheme,
				BearerFormat = AppConstants.SwaggerConstants.OpenApiSecuritySchemeBearerFormat,
				In = ParameterLocation.Header,
				Description = AppConstants.SwaggerConstants.SwaggerJwtAuthorizationDescription
			});

			swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
			{
				{
					new OpenApiSecurityScheme
					{
						Reference = new OpenApiReference
						{
							Type = ReferenceType.SecurityScheme,
							Id = AppConstants.SwaggerConstants.OpenApiSecurityScheme
						}
					},
					Array.Empty<string>()
				}
			});
		});
	}

	public static void AddAuthenticationWithJwtBearer(this IServiceCollection collection, JwtOptions jwtOptions)
	{
		var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey));

		collection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
		.AddJwtBearer(options =>
		{
			options.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidateLifetime = true,
				ValidateIssuerSigningKey = true,
				ValidIssuer = jwtOptions.Issuer,
				ValidAudience = jwtOptions.Audience,
				IssuerSigningKey = signingKey
			};
		});
	}

	public static void MigrateDatabase(this WebApplication app)
	{
		using var scope = app.Services.CreateScope();
		var context = scope.ServiceProvider.GetRequiredService<TestTaskDbContext>();
		context.Database.Migrate();
	}
}
