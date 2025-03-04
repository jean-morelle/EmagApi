using EmagApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagApi.Core.ServicesProvider.Interfaces
{
    public interface IFiliereServices
    {
        Task<List<Filiere>> GetAllFiliereAsync();
        Task<Filiere> GetFiliereByIdAsync(int id);
        Task AddFiliereAsync(Filiere filiere);
        Task DeleteFiliereAsync(int id);
        Task UpdateFiliereAsync(Filiere filiere);
    }
}
