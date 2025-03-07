using EmagApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmagApi.Infrastructure.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Professeur> Professeurs { get; set; }
        public DbSet<Matiere> Matieres { get; set; }
        public DbSet<Filiere> Filieres { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Emargement> Emargements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring relationships and foreign keys
            modelBuilder.Entity<Emargement>()
                .HasOne(e => e.Professeur)
                .WithMany(p => p.Emargements)
                .HasForeignKey(e => e.ProfesseurId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Emargement>()
                .HasOne(e => e.Matiere)
                .WithMany(m => m.Emargements)
                .HasForeignKey(e => e.MatiereId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Emargement>()
                .HasOne(e => e.Filiere)
                .WithMany(f => f.Emargements)
                .HasForeignKey(e => e.FiliereId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Emargement>()
                .HasOne(e => e.Site)
                .WithMany(s => s.Emargements)
                .HasForeignKey(e => e.SiteId)
                .OnDelete(DeleteBehavior.Cascade);

            // Max length configuration for string fields
            modelBuilder.Entity<Professeur>()
                .Property(p => p.Nom)
                .HasMaxLength(100); // Assuming "Nom" has a max length of 100 characters

            modelBuilder.Entity<Filiere>()
                .Property(f => f.Nom)
                .HasMaxLength(100); // Similarly for "Filiere"
        }
    }
}
