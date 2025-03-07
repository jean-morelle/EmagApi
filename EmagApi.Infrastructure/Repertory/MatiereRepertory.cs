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
    public class MatiereRepertory: IMatiereRepertory
    {
        private readonly ApplicationDbContext dbContext;

        public MatiereRepertory(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Add(Matiere matiere)
        {
            dbContext.Matieres.Add(matiere);
            await dbContext.SaveChangesAsync();
            
        }
        public async Task Delete(int id)
        {
            var matiere = await dbContext.Matieres.FindAsync(id);
            if (matiere is not null)
            {
                dbContext.Matieres.Remove(matiere);
                await dbContext.SaveChangesAsync();
            }
        }


        public async Task<IEnumerable<Matiere>> GetAll()
        {
            var matiere = await dbContext.Matieres.ToListAsync();
            return matiere;
        }

        public async Task<Matiere> GetById(int id)
        {
            var matiere = await dbContext.Matieres.FindAsync(id);
            return matiere;
        }

        public async Task Update(Matiere matiere)
        {
            dbContext.Matieres.Update(matiere);
            await dbContext.SaveChangesAsync();
         
        }
    }
}
