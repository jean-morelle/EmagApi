using EmagApi.Core.Models;
using EmagApi.Core.ServiceProvider.Interface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EmagApi.Core.ServiceProvider
{
    public class EmargementServices : IEmargementServices
    {
        private readonly HttpClient httpClient;
        private static string EmargementUri = "api/Emargement";

        public EmargementServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Emargement>> GetAll()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Emargement>>(EmargementUri);
        }

        public async Task<Emargement> GetById(int id)
        {
            return await httpClient.GetFromJsonAsync<Emargement>($"{EmargementUri}/{id}");
        }

        public async Task Add(Emargement emargement)
        {
            var response = await httpClient.PostAsJsonAsync(EmargementUri, emargement);
            response.EnsureSuccessStatusCode();
        }

        public async Task Update(Emargement emargement)
        {
            var response = await httpClient.PutAsJsonAsync($"{EmargementUri}/{emargement.Id}", emargement);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete(int id)
        {
            var response = await httpClient.DeleteAsync($"{EmargementUri}/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<Emargement?> GetEmargementByDetails(int professeurId, DateTime heureDebut, DateTime heureFin, int? matiereId = null, int? siteId = null)
        {
            var queryParams = new List<string>
            {
                $"professeurId={professeurId}",
                $"heureDebut={heureDebut:O}", // Format ISO 8601
                $"heureFin={heureFin:O}"
            };

            if (matiereId.HasValue)
                queryParams.Add($"matiereId={matiereId.Value}");
            if (siteId.HasValue)
                queryParams.Add($"siteId={siteId.Value}");

            string requestUri = $"{EmargementUri}/search?{string.Join("&", queryParams)}";

            return await httpClient.GetFromJsonAsync<Emargement?>(requestUri);
        }
    }
}
