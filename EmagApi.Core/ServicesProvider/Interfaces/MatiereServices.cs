using EmagApi.Domain.Models;
using EmagApi.Core.ServicesProvider.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EmagApi.Core.ServicesProvider
{
    public class MatiereServices : IMatiereServices
    {
        private static string MatiereUri = "api/Matiere";
        private readonly HttpClient _httpClient;

        public MatiereServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddMatiereAsync(Matiere matiere)
        {
            var response = await _httpClient.PostAsJsonAsync(MatiereUri, matiere);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error adding Matiere");
            }
        }

        public async Task DeleteMatiereAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{MatiereUri}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error deleting Matiere");
            }
        }

        public async Task<List<Matiere>> GetAllMatieresAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Matiere>>(MatiereUri);
            if (response == null)
            {
                throw new Exception("Error fetching Matieres");
            }
            return response;
        }

        public async Task<Matiere> GetMatiereByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<Matiere>($"{MatiereUri}/{id}");
            if (response == null)
            {
                throw new Exception("Error fetching Matiere");
            }
            return response;
        }

        public async Task UpdateMatiereAsync(Matiere matiere)
        {
            var response = await _httpClient.PutAsJsonAsync($"{MatiereUri}/{matiere.Id}", matiere);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error updating Matiere");
            }
        }
    }
}
