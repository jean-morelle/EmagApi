using EmagApi.Domain.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace EmagApi.Core.ServicesProvider.Interfaces
{
    public class SeanceServices : ISeanceServices
    {
        private readonly HttpClient httpClient;
        private const string SeanceUri = "api/Seance";

        public SeanceServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Seance>> GetAllSeances()
        {
            return await httpClient.GetFromJsonAsync<List<Seance>>($"{SeanceUri}");
        }

        //public async Task<List<Seance>> GetSeancesByProfesseurNameAsync(string NomDuProfesseur)
        //{
        //    return await httpClient.GetFromJsonAsync<List<Seance>>($"{SeanceUri}/{NomDuProfesseur}");
        //}

        public async Task<Seance> GetSeanceByIdAsync(int id)
        {
            return await httpClient.GetFromJsonAsync<Seance>($"{SeanceUri}/{id}");
        }

        public async Task AddSeanceAsync(Seance seance)
        {
            var response = await httpClient.PostAsJsonAsync(SeanceUri, seance);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateSeanceAsync(Seance seance)
        {
            var response = await httpClient.PutAsJsonAsync($"{SeanceUri}/{seance.Id}", seance);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteSeanceAsync(int id)
        {
            var response = await httpClient.DeleteAsync($"{SeanceUri}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
