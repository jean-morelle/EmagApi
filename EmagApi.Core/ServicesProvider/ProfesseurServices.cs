using EmagApi.Core.ServicesProvider.Interfaces;
using EmagApi.Domain.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace EmagApi.Core.ServicesProvider
{
    public class ProfesseurServices : IProfesseurServices
    {
        private static string ProfesseurUri = "api/Professeur";
        private readonly HttpClient httpClient;

        public ProfesseurServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task AddProfesseurAsync(Professeur professeur)
        {
            var response = await httpClient.PostAsJsonAsync(ProfesseurUri, professeur);
            response.EnsureSuccessStatusCode();
        }

       


        public async Task DeleteProfesseurAsync(int id)
        {
            var response = await httpClient.DeleteAsync($"{ProfesseurUri}/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Professeur>> GetAllProfesseursAsync()
        {
            var response = await httpClient.GetAsync(ProfesseurUri);
            var json = await response.Content.ReadAsStringAsync();

            Console.WriteLine("Réponse JSON reçue : " + json); // 🔍 Debug

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Erreur API : {response.StatusCode} - {json}");
            }

            return JsonSerializer.Deserialize<List<Professeur>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? new List<Professeur>();
        }


        public async Task<Professeur?> GetProfesseurByIdAsync(int id)
        {
            return await httpClient.GetFromJsonAsync<Professeur>($"{ProfesseurUri}/{id}");
        }

        public async Task UpdateProfesseurAsync(Professeur professeur)
        {
            var response = await httpClient.PutAsJsonAsync($"{ProfesseurUri}/{professeur.Id}", professeur);
            response.EnsureSuccessStatusCode();
        }

       

      
    }
}
