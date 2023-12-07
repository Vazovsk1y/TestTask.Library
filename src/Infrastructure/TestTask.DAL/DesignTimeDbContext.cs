using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TestTask.DAL;

internal class DesignTimeDbContext : IDesignTimeDbContextFactory<TestTaskDbContext>
{
	private const string ConnectionString = $"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TestTaskThirdDb;Integrated Security=True;Connect Timeout=30;";

	public TestTaskDbContext CreateDbContext(string[] args)
	{
		var optionsBuilder = new DbContextOptionsBuilder<TestTaskDbContext>();
		optionsBuilder.UseSqlServer(ConnectionString);
		return new TestTaskDbContext(optionsBuilder.Options);
	}
}
