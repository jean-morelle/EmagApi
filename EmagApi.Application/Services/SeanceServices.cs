using EmagApi.Domain.Interface;
using EmagApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmagApi.Infrastructure.Services
{
    public class SeanceService:ISeanceServices
    {
        private readonly ISeanceRepertory _seanceRepertory;

        public SeanceService(ISeanceRepertory seanceRepertory)
        {
            _seanceRepertory = seanceRepertory;
        }

        // Ajouter une séance
        public async Task AddSeanceAsync(Seance seance)
        {
            // Logique métier avant d'ajouter la séance
            // Exemple : vérifier des règles métier si nécessaire

            await _seanceRepertory.AddSeanceAsync(seance);
        }

        // Mettre à jour une séance
        public async Task UpdateSeanceAsync(Seance seance)
        {
            // Logique métier avant la mise à jour
            // Exemple : vérifier si la séance existe déjà

            await _seanceRepertory.UpdateSeanceAsync(seance);
        }

        // Supprimer une séance
        public async Task DeleteSeanceAsync(int id)
        {
            // Logique métier avant la suppression
            // Exemple : vérifier si la séance existe, si l'utilisateur a les droits, etc.

            await _seanceRepertory.DeleteSeanceAsync(id);
        }

        // Récupérer toutes les séances par nom du professeur
        //public async Task<List<Seance>> GetSeancesByProfesseurNameAsync(string nomDuProfesseur)
        //{
        //    if (string.IsNullOrWhiteSpace(nomDuProfesseur))
        //    {
        //        throw new ArgumentException("Le nom du professeur ne peut pas être vide.", nameof(nomDuProfesseur));
        //    }

        //    return await _seanceRepertory.GetSeancesByProfesseurNameAsync(nomDuProfesseur);
        //}

        // Récupérer toutes les séances associées à un professeur
        public async Task<IEnumerable<Seance>> GetAllSeances()
        {
            return await _seanceRepertory.GetAllSeances();
        }

        // Récupérer une séance par son ID
        public async Task<Seance> GetSeanceByIdAsync(int id)
        {
            var seance = await _seanceRepertory.GetSeanceByIdAsync(id);
            if (seance == null)
            {
                throw new Exception("La séance n'a pas été trouvée.");
            }

            return seance;
        }
    }
}
