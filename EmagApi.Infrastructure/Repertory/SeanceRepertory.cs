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
    public class SeanceRepertory:ISeanceRepertory
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


        public async Task<List<Seance>> GetSeancesByProfesseurNameAsync(string nomDuProfesseur)
        {
            if (string.IsNullOrWhiteSpace(nomDuProfesseur))
            {
                throw new ArgumentException("Le nom du professeur ne peut pas être vide.", nameof(nomDuProfesseur));
            }

            return await dbContext.Seances
                .Where(s => s.Professeur != null && s.Professeur.Nom == nomDuProfesseur)  
                .Include(s => s.Professeur) 
                .ToListAsync();
        }


        public async Task<IEnumerable<Seance>> GetSeancesByProfesseurIdAsync(int professeurId)
        {
            var seance = await dbContext.Seances.Include(s=>s.Professeur).Where(s => s.ProfesseurId == professeurId).ToListAsync();
            return seance;
        }

        public Task<Seance> GetSeanceByIdAsync(int id)
        {
          var seance = dbContext.Seances.Include(s => s.Professeur).FirstOrDefaultAsync(s => s.Id == id);
           return seance;
        }

        public async Task UpdateSeanceAsync(Seance seance)
        {
            dbContext.Seances.Update(seance);
            await dbContext.SaveChangesAsync();
        }
    }
}
