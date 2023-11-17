using Microsoft.EntityFrameworkCore;
using web_api;

public class MyContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public MyContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer//(@"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True");
        (@"Data Source=DESKTOP-HT0TC5T\SQLEXPRESS;Initial Catalog=Sibiu Rewards;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }
}