using EmagApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagApi.Domain.Interface
{
    public interface IFiliereServices
    {
        Task<IEnumerable<Filiere>> GetAll();
        Task<Filiere> GetById(int id);
        Task Add(Filiere filiere);
        Task Delete(int id);
        Task Update(Filiere filiere);
    }
}
