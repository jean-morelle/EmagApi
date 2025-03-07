using EmagApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagApi.Domain.Interface
{
    public interface ISiteRepertory
    {
        Task<IEnumerable<Site>> GetAll();
        Task<Site>GetById(int id);
        Task Add(Site site);
        Task Update(Site site);
        Task Delete(int id);
    }
}
