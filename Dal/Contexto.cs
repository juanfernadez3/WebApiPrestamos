using Microsoft.EntityFrameworkCore;
using PrimerRegistro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerRegistro.Dal
{
    public class Contexto: DbContext
    {
        public DbSet<Personas> Personas { get; set; }
        public DbSet<Prestamos> Prestamos { get; set; }
        public DbSet<Moras> Moras { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= DATA\Prestamos.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personas>()
            .HasOne<Prestamos>(s => s.Prestamos)
            .WithOne(ad => ad.Personas)
            .HasForeignKey<Prestamos>(ad => ad.PersonaID);
        }
    }
}
