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
        public async Task Add(Filiere filiere)
        {
            applicationDbContext.Filieres.Add(filiere);
            await applicationDbContext.SaveChangesAsync();
           
        }
        public async Task Delete(int id)
        {
            var filiere = await applicationDbContext.Filieres.FindAsync(id);
            if (filiere is not null)
            {
                applicationDbContext.Filieres.Remove(filiere);
                await applicationDbContext.SaveChangesAsync();
            }

          
        }


        public async Task<IEnumerable<Filiere>> GetAll()
        {
            var filiere = await applicationDbContext.Filieres.ToListAsync();
            return filiere;
        }

        public async Task<Filiere> GetById(int id)
        {
            var filiere = await applicationDbContext.Filieres.FindAsync(id);
            return filiere;
        }

        public async Task Update(Filiere filiere)
        {
            applicationDbContext.Filieres.Update(filiere);
            await applicationDbContext.SaveChangesAsync();
            
        }

    }
}
