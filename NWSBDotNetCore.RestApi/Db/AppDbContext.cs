using Microsoft.EntityFrameworkCore;
using NWSBDotNetCore.RestApi;
using NWSBDotNetCore.RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWSBDotNetCore.ConsoleApp.Connections
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<BLogModel> Blogs { get; set; }
    }
}
