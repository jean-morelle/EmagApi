using EmagApi.Domain.Interface;
using EmagApi.Domain.Models;
using EmagApi.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagApi.Infrastructure.Repertory
{
    public class SeanceRepertory : ISeanceRepertory
    {
        private readonly ApplicationDbContext dbContext;

        public SeanceRepertory(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddSeanceAsync(Seance seance)
        {
            var professeurExiste = await dbContext.Professeurs.AnyAsync(p => p.Id == seance.ProfesseurId);
            if (!professeurExiste)
            {
                throw new Exception("Le professeur spécifié n'existe pas.");
            }

            // Calculer le nombre d'heures avant l'ajout
          //  seance.MettreAJourNombreHeures();

            dbContext.Seances.Add(seance);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteSeanceAsync(int id)
        {
            var seance = await dbContext.Seances.FirstOrDefaultAsync(s => s.Id == id);

            if (seance == null)
            {
                throw new ArgumentException("La séance n'existe pas.");
            }

            dbContext.Seances.Remove(seance);
            await dbContext.SaveChangesAsync();
        }

        //public async Task<List<Seance>> GetSeancesByProfesseurNameAsync(string nomDuProfesseur)
        //{
        //    if (string.IsNullOrWhiteSpace(nomDuProfesseur))
        //    {
        //        throw new ArgumentException("Le nom du professeur ne peut pas être vide.", nameof(nomDuProfesseur));
        //    }

        //    var seances = await dbContext.Seances
        //        .Where(s => s.Professeur != null && s.Professeur.Nom == nomDuProfesseur)
        //        .Include(s => s.Professeur)
        //        .ToListAsync();

        //    // Mettre à jour le nombre d'heures de chaque séance
        //    foreach (var seance in seances)
        //    {
        //        seance.MettreAJourNombreHeures();
        //    }

        //    return seances;
        //}

        public async Task<IEnumerable<Seance>> GetAllSeances()
        {
            var seances = await dbContext.Seances.Include(s => s.Professeur).ToListAsync();

            // Mettre à jour le nombre d'heures de chaque séance
            //foreach (var seance in seances)
            //{
            //    seance.MettreAJourNombreHeures();
            //}

            return seances;
        }

        public async Task<Seance> GetSeanceByIdAsync(int id)
        {
            var seance = await dbContext.Seances
                .Include(s => s.Professeur)
                .FirstOrDefaultAsync(s => s.Id == id);

            // Mettre à jour le nombre d'heures pour cette séance
            //if (seance != null)
            //{
            //    seance.MettreAJourNombreHeures();
            //}

            return seance;
        }

        public async Task UpdateSeanceAsync(Seance seance)
        {
            // Mettre à jour le nombre d'heures avant la mise à jour
           // seance.MettreAJourNombreHeures();

            dbContext.Seances.Update(seance);
            await dbContext.SaveChangesAsync();
        }
    }
}
