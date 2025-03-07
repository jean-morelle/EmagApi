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
    public class SiteRepertory:ISiteRepertory
    {
        private readonly ApplicationDbContext dbContext;

        public SiteRepertory(ApplicationDbContext dbContext )
        {
            this.dbContext = dbContext;
        }
        public async Task Add(Site site)
        {
            dbContext.Sites.Add(site);
            await dbContext.SaveChangesAsync();
           
        }
        public async Task Delete(int id)
        {
            var site = await dbContext.Sites.FindAsync(id);
            if (site is not null)
            {
                dbContext.Sites.Remove(site);
                await dbContext.SaveChangesAsync();
            }
            
        }



        public async Task<IEnumerable<Site>> GetAll()
        {
            var site = await dbContext.Sites.ToListAsync();
            return site;
        }

        public async Task<Site> GetById(int id)
        {
            var site = await dbContext.Sites.FindAsync(id);
            return site;
        }

        public async Task Update(Site site)
        {
            dbContext.Sites.Update(site);
            await dbContext.SaveChangesAsync();
            
        }
    }
}
