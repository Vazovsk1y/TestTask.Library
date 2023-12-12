using Microsoft.EntityFrameworkCore;
using TestTask.DAL;
using TestTask.Application.Implementations;
using TestTask.WebApi.Middlewares;
using TestTask.WebApi;
using TestTask.Application.Implementations.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

const string JwtSectionName = "Jwt";

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplicationLayer();
builder.Services.AddDataAccessLayer(builder.Configuration);
builder.Services.AddTransient<ExceptionsHandlingMiddleware>();
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(JwtSectionName));
builder.Services.AddAuthenticationWithJwtBearer(builder.Configuration.GetSection(JwtSectionName).Get<JwtOptions>()!);
builder.Services.AddSwaggerWithJwtSecurity();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseMiddleware<ExceptionsHandlingMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
	using var scope = app.Services.CreateScope();
	var context = scope.ServiceProvider.GetRequiredService<TestTaskDbContext>();
	await context.Database.MigrateAsync();
}

app.Run();
