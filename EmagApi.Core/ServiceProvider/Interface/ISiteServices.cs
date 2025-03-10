using EmagApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagApi.Core.ServiceProvider.Interface
{
    public interface ISiteServices
    {
        Task<List<Site>> GetAll();
        Task<Site> GetById(int id);
        Task Add(Site site);
        Task Update(Site site);
        Task Delete(int id);
    }
}
