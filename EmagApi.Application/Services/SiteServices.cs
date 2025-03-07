using EmagApi.Domain.Interface;
using EmagApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagApi.Application.Services
{
    public class SiteServices:ISiteServices
    {
        private readonly ISiteRepertory siteRepertory;

        public SiteServices(ISiteRepertory siteRepertory)
        {
            this.siteRepertory = siteRepertory;
        }

        public async Task Add(Site site)
        {
            await siteRepertory.Add(site);
        }

        public async Task Delete(int id)
        {
            await siteRepertory.Delete(id);
        }

        public Task<IEnumerable<Site>> GetAll()
        {
            return siteRepertory.GetAll();
        }

        public Task<Site> GetById(int id)
        {
            return siteRepertory.GetById(id);
        }

        public async Task Update(Site site)
        {
           await siteRepertory.Update(site);
        }
    }
}
