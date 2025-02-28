using EmagApi.Domain.Interface;
using EmagApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagApi.Application.Services
{
    public class ProfesseurServices:IProfesseurServices
    {
        private readonly IProfesseurRepertory professeurRepertory;

        public ProfesseurServices(IProfesseurRepertory professeurRepertory)
        {
            this.professeurRepertory = professeurRepertory;
        }

        public async Task AddProfesseurAsync(Professeur professeur)
        {
            await professeurRepertory.AddProfesseurAsync(professeur);
        }

        public async Task DeleteProfesseurAsync(int id)
        {
            await professeurRepertory.DeleteProfesseurAsync(id);
        }

        public async Task<List<Professeur>> GetAllProfesseursAsync()
        {
          var professeur = await professeurRepertory.GetAllProfesseursAsync();
            return professeur;
        }

        public async Task<Professeur> GetProfesseurByIdAsync(int id)
        {
            var professeur = await professeurRepertory.GetProfesseurByIdAsync(id);
            return professeur;
        }

        public async Task UpdateProfesseurAsync(Professeur professeur)
        {
           await professeurRepertory.UpdateProfesseurAsync(professeur);
        }
    }
}
