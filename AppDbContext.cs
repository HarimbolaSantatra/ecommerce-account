using Microsoft.EntityFrameworkCore;

namespace Account;

public class AppDbContext : DbContext
{

    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
	var DbHost = Environment.GetEnvironmentVariable("DB_HOST");
	if (DbHost == null) DbHost = "localhost";
	optionsBuilder.UseMySQL($"server={DbHost};database=account_microservice;user=root;password=root");
    }

}
