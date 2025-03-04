using System.Net.Http.Json;
using EmagApi.Core.ServicesProvider.Interfaces;
using EmagApi.Domain.Models; // Assurez-vous que le modèle Filiere existe

namespace EmagApi.Core.Services
{
    public class FiliereService:IFiliereServices
    {
        private readonly HttpClient _httpClient;
        private const string FiliereUri = "api/Filiere";

        public FiliereService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<Filiere?> GetFiliereByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Filiere>($"{FiliereUri}/{id}");
        }

        public async Task AddFiliereAsync(Filiere filiere)
        {
            var response = await _httpClient.PostAsJsonAsync(FiliereUri, filiere);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateFiliereAsync( Filiere filiere)
        {
            var response = await _httpClient.PutAsJsonAsync($"{FiliereUri}/{filiere.Id}", filiere);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteFiliereAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{FiliereUri}/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Filiere>> GetAllFiliereAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Filiere>>(FiliereUri);
        }
    }
}
