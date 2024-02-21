using DemoProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Data;

public class AppDataContext : DbContext
{

    public AppDataContext(DbContextOptions<AppDataContext> context) : base(context)
    {

    }
    
    public DbSet<Car> Cars { get; set; }
    
}