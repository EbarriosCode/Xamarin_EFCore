using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamEFCore.Models
{
    public class ProductsDbContext : DbContext
    {
        string DbPath = string.Empty;

        public ProductsDbContext() : this("efCore.db")
        {            
        }

        public ProductsDbContext(string dbPath)
        {
            this.DbPath = dbPath;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<IngenioSINSRow> Ingenios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={DbPath}");            
        }
    }
}
