﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWSBDotNetCore.ConsoleApp
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<BloDto> Blogs { get; set; }
    }
}