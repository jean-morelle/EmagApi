using EmagApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagApi.Domain.Interface
{
    public interface ISeanceServices
    {
        Task<IEnumerable<Seance>> GetSeancesByProfesseurIdAsync(int professeurId);
        Task<List<Seance>> GetSeancesByProfesseurNameAsync(string NomDuProfesseur);
        Task<Seance> GetSeanceByIdAsync(int id);
        Task AddSeanceAsync(Seance seance);
        Task UpdateSeanceAsync(Seance seance);
        Task DeleteSeanceAsync(int id);
    }
}
