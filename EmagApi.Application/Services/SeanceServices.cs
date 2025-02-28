using EmagApi.Domain.Interface;
using EmagApi.Domain.Models;
using EmagApi.Infrastructure.Repertory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagApi.Application.Services
{
    public class SeanceServices:ISeanceServices
    {
        private readonly ISeanceRepertory seanceRepertory;

        public SeanceServices(ISeanceRepertory seanceRepertory)
        {
            this.seanceRepertory = seanceRepertory;
        }

        public async Task AddSeanceAsync(Seance seance)
        {
            await seanceRepertory.AddSeanceAsync(seance);
        }

        public async Task DeleteSeanceAsync(int id)
        {
           await seanceRepertory.DeleteSeanceAsync(id);
        }

        public async Task<List<Seance>> GetSeancesByProfesseurNameAsync(string NomDuProfesseur)
        {
           var seance = await seanceRepertory.GetSeancesByProfesseurNameAsync(NomDuProfesseur);
            return seance;
        }

        

        public async Task<Seance> GetSeanceByIdAsync(int id)
        {
            var seance = await seanceRepertory.GetSeanceByIdAsync(id);
            return seance;
        }

        public async Task UpdateSeanceAsync(Seance seance)
        {
          await seanceRepertory.UpdateSeanceAsync(seance);
        }

        public async Task<IEnumerable<Seance>> GetSeancesByProfesseurIdAsync(int professeurId)
        {
            if (professeurId <= 0)
            {
                throw new ArgumentException("L'ID du professeur doit être valide.", nameof(professeurId));
            }

            var seances = await seanceRepertory.GetSeancesByProfesseurIdAsync(professeurId);

            if (seances == null || !seances.Any())
            {
                throw new KeyNotFoundException("Aucune séance trouvée pour ce professeur.");
            }

            return seances;
        }
    }
}
