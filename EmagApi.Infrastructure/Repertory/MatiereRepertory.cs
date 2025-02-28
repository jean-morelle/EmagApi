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

        public Task AddMatiereAsync(Matiere matiere)
        {
          dbContext.Matiere.Add(matiere);
            return dbContext.SaveChangesAsync();
        }

        public async Task DeleteMatiereAsync(int id)
        {
            var matiere = await dbContext.Matiere.FirstOrDefaultAsync(x=>x.Id ==id);
            if(matiere is null)
            {
                throw new Exception();
            }
            else
            {
                dbContext.Matiere.Remove(matiere);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Matiere>> GetAllMatiere()
        {
            var matiere = await dbContext.Matiere.ToListAsync();
            return matiere;
        }

        public async Task<Matiere> GetMatiereByIdAsync(int id)
        {
            var matiere = await dbContext.Matiere.FirstOrDefaultAsync(x => x.Id == id);
            return matiere;
        }

        public async Task UpdateMatiereAsync(Matiere matiere)
        {
            dbContext.Matiere.Update(matiere);
            await dbContext.SaveChangesAsync();
        }
    }
}
