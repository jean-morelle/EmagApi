using EmagApi.Domain.Interface;
using EmagApi.Domain.Models;
using EmagApi.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagApi.Infrastructure.Repertory
{
    public class ProfesseurRepertory:IProfesseurRepertory
    {
        private readonly ApplicationDbContext dbContext;

        public ProfesseurRepertory(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddProfesseurAsync(Professeur professeur)
        {
            dbContext.Professeurs.Add(professeur);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteProfesseurAsync(int id)
        {
           var professeur = await dbContext.Professeurs.FirstOrDefaultAsync(x=>x.Id==id);
            if (professeur is  null)
            {
                throw new Exception($"Impossible de supprimer {id}");
                
            }
            else
            {
                dbContext.Professeurs.Remove(professeur);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Professeur>> GetAllProfesseursAsync()
        {
            var professeur = await dbContext.Professeurs.ToListAsync();
            return professeur;
        }

        public async Task<Professeur> GetProfesseurByIdAsync(int id)
        {
            var professeur = await dbContext.Professeurs.FirstOrDefaultAsync(x=>x.Id==id);
            return professeur;
        }

        public async Task<Professeur> GetProfesseurDetailsByNomAsync(string nom)
        {
            var professeur = await dbContext.Professeurs
                .Where(p => p.Nom.Contains(nom))
                .Include(p => p.Seances) // Inclure les séances du professeur
                .ThenInclude(s => s.SeanceMatieres) // Inclure la table de jonction des matières
                .ThenInclude(sm => sm.Matiere) // Inclure les matières associées à la séance
                .FirstOrDefaultAsync(); // Récupérer le premier professeur trouvé

            if (professeur != null)
            {
                // Charger les filières des matières associées
                foreach (var seance in professeur.Seances)
                {
                    foreach (var seanceMatiere in seance.SeanceMatieres)
                    {
                        var matiere = seanceMatiere.Matiere;
                        // Charger la filière pour chaque matière
                        //await dbContext.Entry(matiere).Reference(m => m.Filiere).LoadAsync();
                    }
                }
            }

            return professeur; // Retourner l'objet Professeur avec ses relations et filières chargées
        }




        public Task UpdateProfesseurAsync(Professeur professeur)
        {
           dbContext.Professeurs.Update(professeur);
            return dbContext.SaveChangesAsync();
        }
    }
}
