using Microsoft.EntityFrameworkCore;
using TiramisuService.Models;

namespace TiramisuService.Database;

public class ClothingContext : DbContext
{
    public DbSet<ClothingRequest> ClothingRequests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=clothing.db");
    }
}