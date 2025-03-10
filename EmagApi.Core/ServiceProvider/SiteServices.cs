using EmagApi.Core.Models;
using EmagApi.Core.ServiceProvider.Interface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EmagApi.Core.ServiceProvider
{
    public class SiteServices : ISiteServices
    {
        private readonly HttpClient httpClient;
        private static string SiteUri = "api/Site";

        public SiteServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Site>> GetAll()
        {
            return await httpClient.GetFromJsonAsync<List<Site>>(SiteUri);
        }

        public async Task<Site> GetById(int id)
        {
            return await httpClient.GetFromJsonAsync<Site>($"{SiteUri}/{id}");
        }

        public async Task Add(Site site)
        {
            var response = await httpClient.PostAsJsonAsync(SiteUri, site);
            response.EnsureSuccessStatusCode();
        }

        public async Task Update(Site site)
        {
            var response = await httpClient.PutAsJsonAsync($"{SiteUri}/{site.Id}", site);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete(int id)
        {
            var response = await httpClient.DeleteAsync($"{SiteUri}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
