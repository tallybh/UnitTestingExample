using Microsoft.EntityFrameworkCore;
using System.Net;
using UnitTestingExample.Model;

namespace UnitTestingExample.Models;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    protected readonly DbContextOptions Configuration;
    public AppDbContext(DbContextOptions configuration) : base(configuration)
    {
        Configuration = configuration;
    }

}


