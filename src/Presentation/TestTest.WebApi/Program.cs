using TestTask.Application.Implementations;
using TestTask.WebApi.Middlewares;
using TestTask.WebApi;
using TestTask.Application.Implementations.Services;
using TestTask.DAL.SqlServer.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplicationLayer();
builder.Services.AddDataAccessLayer(builder.Configuration);
builder.Services.AddTransient<ExceptionsHandlingMiddleware>();
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(AppConstants.JwtSectionName));
builder.Services.AddAuthenticationWithJwtBearer(builder.Configuration.GetSection(AppConstants.JwtSectionName).Get<JwtOptions>()!);
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
	app.MigrateDatabase();
}

app.Run();
