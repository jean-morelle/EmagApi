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
        Task<IEnumerable<Filiere>> GetAllFiliereAsync();
        Task<Filiere> GetFiliereByIdAsync(int id);
        Task AddFiliereAsync(Filiere filiere);
        Task DeleteFiliereAsync(int id);
        Task UpdateFiliereAsync(Filiere filiere);
    }
}
