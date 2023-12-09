using Microsoft.EntityFrameworkCore;
using TestTask.DAL;
using TestTask.Application.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationLayer();
builder.Services.AddDataAccessLayer(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
	using var scope = app.Services.CreateScope();
	var context = scope.ServiceProvider.GetRequiredService<TestTaskDbContext>();
	await context.Database.MigrateAsync();
}

app.Run();
