using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ZgloszeniaAwari.Entities
{
    internal class ZgloszeniaAwariiDbContext : DbContext
    {
        public DbSet<Kategoria> Kategorje { get; set; }
        public DbSet<Osoba> Osoby { get; set; }
        public DbSet<Zgloszenie> Zgloszenia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Osoba>()
                 .HasMany(o => o.zgloszenia)
                 .WithOne(z => z.PrzypisaneDo)
                 .HasForeignKey(z => z.PrzypisaneDoId)
                 .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Zgloszenie>()
                .HasOne(z => z.TworcaZgloszenia)
                .WithMany()
                .HasForeignKey(z => z.TworcaZgloszeniaId);

            modelBuilder.Entity<Kategoria>()
                .HasOne(k => k.Zgloszenie)
                .WithOne(z => z.Kategoria)
                .HasForeignKey<Zgloszenie>(z => z.KategoriaId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = ZgloszeniaAwariiDb; Trusted_Connection = True;");
        }
    }
}