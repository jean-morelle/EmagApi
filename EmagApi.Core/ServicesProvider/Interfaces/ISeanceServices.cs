using EmagApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagApi.Core.ServicesProvider.Interfaces
{
    public interface ISeanceServices
    {
        Task<List<Seance>> GetAllSeances();
      //  Task<List<Seance>> GetSeancesByProfesseurNameAsync(string NomDuProfesseur);
        Task<Seance> GetSeanceByIdAsync(int id);
        Task AddSeanceAsync(Seance seance);
        Task UpdateSeanceAsync(Seance seance);
        Task DeleteSeanceAsync(int id);
    }
}
