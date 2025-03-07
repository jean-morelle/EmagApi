using EmagApi.Core.Models;
using EmagApi.Core.ServiceProvider.Interface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EmagApi.Core.ServiceProvider
{
    public class ProfesseurServices : IProfesseurServices
    {
        private static string ProfesseurUri = "api/Professeur";
        private readonly HttpClient httpClient;

        public ProfesseurServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Professeur>> GetAll()
        {
            return await httpClient.GetFromJsonAsync<List<Professeur>>(ProfesseurUri);
        }

        public async Task<Professeur> GetById(int id)
        {
            return await httpClient.GetFromJsonAsync<Professeur>($"{ProfesseurUri}/{id}");
        }

        public async Task Add(Professeur professeur)
        {
            var response = await httpClient.PostAsJsonAsync(ProfesseurUri, professeur);
            response.EnsureSuccessStatusCode();
        }

      public async Task Update(Professeur professeur)
{
    try
    {
        var response = await httpClient.PutAsJsonAsync($"{ProfesseurUri}/{professeur.Id}", professeur);
        
        // Check if the response was successful
        response.EnsureSuccessStatusCode();
    }
    catch (HttpRequestException e)
    {
        // Log or handle the exception
        Console.WriteLine($"Request failed: {e.Message}");
        throw;
    }
    catch (Exception e)
    {
        // Catch any other unexpected exceptions
        Console.WriteLine($"An unexpected error occurred: {e.Message}");
        throw;
    }
}


        public async Task Delete(int id)
        {
            var response = await httpClient.DeleteAsync($"{ProfesseurUri}/{id}");

            if (!response.IsSuccessStatusCode)
            {
                // Log the response status and content for debugging
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.Error.WriteLine($"Error deleting professor with ID {id}. Status code: {response.StatusCode}, Response: {errorContent}");

                // You can also throw an exception if needed
                throw new HttpRequestException($"Failed to delete professor. Status code: {response.StatusCode}, Response: {errorContent}");
            }

            response.EnsureSuccessStatusCode(); // EnsureSuccessStatusCode will throw if it's not a success status code
        }

    }
}
