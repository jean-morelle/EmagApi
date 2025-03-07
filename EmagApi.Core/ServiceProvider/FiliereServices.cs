using EmagApi.Core.Models;
using EmagApi.Core.ServiceProvider.Interface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EmagApi.Core.ServiceProvider
{
    public class FiliereServices : IFiliereServices
    {
        private static string FiliereUri = "api/Filiere";
        private readonly HttpClient httpClient;

        public FiliereServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Filiere>> GetAll()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Filiere>>(FiliereUri);
        }

        public async Task<Filiere> GetById(int id)
        {
            return await httpClient.GetFromJsonAsync<Filiere>($"{FiliereUri}/{id}");
        }

        public async Task Add(Filiere filiere)
        {
            var response = await httpClient.PostAsJsonAsync(FiliereUri, filiere);
            response.EnsureSuccessStatusCode();
        }

        public async Task Update(Filiere filiere)
        {
            var response = await httpClient.PutAsJsonAsync($"{FiliereUri}/{filiere.Id}", filiere);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete(int id)
        {
            var response = await httpClient.DeleteAsync($"{FiliereUri}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
