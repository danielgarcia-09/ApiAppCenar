using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Database.Models
{
    public partial class ApiCenarContext : DbContext
    {
        public ApiCenarContext()
        {
        }

        public ApiCenarContext(DbContextOptions<ApiCenarContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ingredientes> Ingredientes { get; set; }
        public virtual DbSet<Platos> Platos { get; set; }
        public virtual DbSet<Mesas> Mesas  {get;set;}
        public virtual DbSet<Ordenes> Ordenes  {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
                optionsBuilder.UseSqlServer("Server=LAPTOP-184T66BD\\SQLEXPRESS;Database=ApiCenar;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);

            modelBuilder.Entity<Ingredientes>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Id);

            });

            modelBuilder.Entity<Ordenes>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Id);
                entity.Property(e => e.Estado).HasDefaultValue("En proceso");

            });

            modelBuilder.Entity<Mesas>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Id);
                entity.Property(e => e.Estado).HasDefaultValue("Disponible");

            });

            modelBuilder.Entity<Platos>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Id);

            });

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
