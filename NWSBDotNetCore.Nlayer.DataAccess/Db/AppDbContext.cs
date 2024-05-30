using Microsoft.EntityFrameworkCore;
using NWSBDotNetCore.Nlayer.DataAccess.Models;

namespace NWSBDotNetCore.Nlayer.DataAccess.Db;

internal class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
    }
    public DbSet<BlogModel> Blogs { get; set; }
}
