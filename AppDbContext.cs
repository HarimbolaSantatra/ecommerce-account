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
	optionsBuilder.UseMySQL("server=localhost;database=account_microservice;user=root;password=root");
    }

}
