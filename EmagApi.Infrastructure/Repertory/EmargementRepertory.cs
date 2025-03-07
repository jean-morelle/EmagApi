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
    public class EmargementRepertory:IEmargementRepertory
    {
        private readonly ApplicationDbContext dbContext;

        public EmargementRepertory(ApplicationDbContext dbContext )
        {
            this.dbContext = dbContext;
        }

        public async Task Add(Emargement emargement)
        {
           dbContext.Emargements.Add( emargement );
            await dbContext.SaveChangesAsync();
           
        }

        public async Task Delete(int id)
        {
            var emargement = await dbContext.Emargements.FindAsync( id );
            if (emargement is not null)
            {
                dbContext.Emargements.Remove(emargement);
                await dbContext.SaveChangesAsync();
            }
          
        }

        public async Task<IEnumerable<Emargement>> GetAll()
        {
            var emargement = await dbContext.Emargements
                .Include(e=>e.Professeur)
                 .Include(e=>e.Matiere)
                  .Include(e=>e.Filiere)
                   .Include(e=>e.Site)
                    .ToListAsync();
            return emargement;
                  
        }

        public async Task<Emargement> GetById(int id)
        {
            var emargement = await dbContext.Emargements
                .Include(e => e.Professeur)
                 .Include(e => e.Matiere)
                  .Include(e => e.Filiere)
                   .Include(e => e.Site)
                    .FirstOrDefaultAsync(e=>e.Id == id);
            return emargement;
        }

        public async Task<Emargement?> GetEmargementByDetails(int professeurId, DateTime heureDebut, DateTime heureFin, int? matiereId = null, int? siteId = null)
        {
            // Recherche d'un émargement correspondant aux détails fournis
            var emargement = await dbContext.Emargements
                .Include(e => e.Professeur)
                .Include(e => e.Matiere)
                .Include(e => e.Filiere)
                .Include(e => e.Site)
                .FirstOrDefaultAsync(e =>
                    e.ProfesseurId == professeurId &&
                    ((heureDebut >= e.HeureDebut && heureDebut < e.HeureFin) ||
                    (heureFin > e.HeureDebut && heureFin <= e.HeureFin) ||
                    (heureDebut <= e.HeureDebut && heureFin >= e.HeureFin)) &&
                    (matiereId == null || e.MatiereId == matiereId) &&
                    (siteId == null || e.SiteId == siteId)
                );

            return emargement; // Retourne l'émargement trouvé ou null
        }


        public async Task<bool> HasConflictingEmargement(int professeurId, DateTime heureDebut, DateTime heureFin)
        {
            bool conflict = await dbContext.Emargements.AnyAsync(e =>
                e.ProfesseurId == professeurId &&
                (
                    (heureDebut >= e.HeureDebut && heureDebut < e.HeureFin) ||
                    (heureFin > e.HeureDebut && heureFin <= e.HeureFin) ||
                    (heureDebut <= e.HeureDebut && heureFin >= e.HeureFin)
                )
            );

            Console.WriteLine($"🔍 Conflit détecté ? {conflict} pour ProfesseurId={professeurId} entre {heureDebut} et {heureFin}");

            return conflict;
        }




        public async Task Update(Emargement emargement)
        {
            dbContext.Emargements.Update(emargement);
            await dbContext.SaveChangesAsync();
          
        }
    }
}
