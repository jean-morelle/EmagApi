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
    public class FiliereRepertory : IFiliereRepertory
    {
        private readonly ApplicationDbContext applicationDbContext;

        public FiliereRepertory(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public Task AddFiliereAsync(Filiere filiere)
        {
          applicationDbContext.Filiere.Add(filiere);
            return applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteFiliereAsync(int id)
        {
           var filiere = await applicationDbContext.Filiere.FirstOrDefaultAsync(x => x.Id == id);
            if (filiere == null)
            {
                throw new ArgumentException();
            }
            else
            {
                applicationDbContext.Filiere.Remove(filiere);
                await applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Filiere>> GetAllFiliereAsync()
        {
            var filiere = await applicationDbContext.Filiere.ToListAsync();
            return filiere;
        }

        public async Task<Filiere> GetFiliereByIdAsync(int id)
        {
           var filiere = await applicationDbContext.Filiere.FirstOrDefaultAsync(x=>x.Id==id);
            return filiere;
        }

        public async Task UpdateFiliereAsync(Filiere filiere)
        {
            applicationDbContext.Filiere.Update(filiere);
            await applicationDbContext.SaveChangesAsync();
        }
    }
}
