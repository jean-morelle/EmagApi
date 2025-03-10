using EmagApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagApi.Core.ServiceProvider.Interface
{
    public interface IEmargementServices
    {
        Task<Emargement?> GetEmargementByDetails(int professeurId, DateTime heureDebut, DateTime heureFin, int? matiereId = null, int? siteId = null);
        Task<List<Emargement>> GetAll();
        Task<Emargement> GetById(int id);
        Task Add(Emargement emargement);
        Task Update(Emargement emargement);
        Task Delete(int id);
    }
}
