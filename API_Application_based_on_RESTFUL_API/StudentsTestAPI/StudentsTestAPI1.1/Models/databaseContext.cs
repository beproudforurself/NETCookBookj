using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StudentsTestAPI1._1.Models
{
    public partial class databaseContext : DbContext
    {
        public databaseContext()
        {
        }

        public databaseContext(DbContextOptions<databaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProductPrice> ProductPrices { get; set; } = null!;
        public virtual DbSet<student> students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductPrice>(entity =>
            {
                entity.ToTable("ProductPrice");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
//
/*Scaffold-DbContext "Data Source=database.db" Microsoft.EntityFrameworkCore.Sqlite -OutputDir Models -Force -UseDatabaseNames -Project StudentsTestAPI1.1 -StartupProject StudentsTestAPI1.1*/