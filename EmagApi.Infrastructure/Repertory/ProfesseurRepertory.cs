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

        public async Task Add(Professeur professeur)
        {
            dbContext.Professeurs.Add(professeur);
            await dbContext.SaveChangesAsync();
           
        }

        public async Task Delete(int id)
        {
            try
            {
                // Recherche du professeur par ID
                var professeur = await dbContext.Professeurs.FindAsync(id);

                if (professeur is null)
                {
                    throw new Exception();
                }
              //  dbContext.Emargements.RemoveRange(professeur.Emargements);
                // Suppression du professeur
                dbContext.Professeurs.Remove(professeur);

                // Sauvegarde des changements dans la base de données
                await dbContext.SaveChangesAsync();

              
            }
            catch (Exception ex)
            {
                // Gérer les exceptions ici et peut-être logger l'erreur
                // Par exemple, loguer l'exception (si vous utilisez un framework de logging)
                Console.Error.WriteLine($"Erreur lors de la suppression : {ex.Message}");

                // Vous pouvez aussi retourner une réponse d'erreur ou lever une exception.
                throw new InvalidOperationException("Une erreur est survenue lors de la suppression du professeur.", ex);
            }
        }


        public async Task<IEnumerable<Professeur>> GetAll()
        {
            var professeur = await dbContext.Professeurs.ToListAsync();
            return professeur;
        }

        public async Task<Professeur> GetById(int id)
        {
            var professeur = await dbContext.Professeurs.FindAsync(id);
            return professeur;
        }

        public async Task Update(Professeur professeur)
        {
            dbContext.Professeurs.Update(professeur);
            await dbContext.SaveChangesAsync();
           
        }
    }
}
