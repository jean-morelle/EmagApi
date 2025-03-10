﻿using EmagApi.Core.Models;
using EmagApi.Core.ServiceProvider.Interface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EmagApi.Core.ServiceProvider
{
    public class MatiereServices : IMatiereServices
    {
        private readonly HttpClient httpClient;
        private static string MatiereUri = "api/Matiere";

        public MatiereServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Matiere>> GetAll()
        {
            return await httpClient.GetFromJsonAsync<List<Matiere>>(MatiereUri);
        }

        public async Task<Matiere> GetById(int id)
        {
            return await httpClient.GetFromJsonAsync<Matiere>($"{MatiereUri}/{id}");
        }

        public async Task Add(Matiere matiere)
        {
            var response = await httpClient.PostAsJsonAsync(MatiereUri, matiere);
            response.EnsureSuccessStatusCode();
        }

        public async Task Update(Matiere matiere)
        {
            var response = await httpClient.PutAsJsonAsync($"{MatiereUri}/{matiere.Id}", matiere);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete(int id)
        {
            var response = await httpClient.DeleteAsync($"{MatiereUri}/{id}");

            if (!response.IsSuccessStatusCode)
            {
                // Log the response status and content for debugging
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.Error.WriteLine($"Error deleting matiere with ID {id}. Status code: {response.StatusCode}, Response: {errorContent}");

                // You can also throw an exception if needed
                throw new HttpRequestException($"Failed to delete matiere. Status code: {response.StatusCode}, Response: {errorContent}");
            }

            response.EnsureSuccessStatusCode(); // EnsureSuccessStatusCode will throw if it's not a success status code
        }
    }
}
