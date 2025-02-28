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

        public Task UpdateProfesseurAsync(Professeur professeur)
        {
           dbContext.Professeurs.Update(professeur);
            return dbContext.SaveChangesAsync();
        }
    }
}
