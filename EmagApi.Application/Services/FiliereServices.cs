using EmagApi.Domain.Interface;
using EmagApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagApi.Application.Services
{
    public class FiliereServices:IFiliereServices
    {
        private readonly IFiliereRepertory filiereRepertory;

        public FiliereServices(IFiliereRepertory filiereRepertory)
        {
            this.filiereRepertory = filiereRepertory;
        }

        public async Task AddFiliereAsync(Filiere filiere)
        {
            await filiereRepertory.AddFiliereAsync(filiere);
        }

        public async Task DeleteFiliereAsync(int id)
        {
            await filiereRepertory.DeleteFiliereAsync(id);
        }

        public async Task<IEnumerable<Filiere>> GetAllFiliereAsync()
        {
          var filiere = await filiereRepertory.GetAllFiliereAsync();
            return filiere;
        }

        public async Task<Filiere> GetFiliereByIdAsync(int id)
        {
            var filiere = await filiereRepertory.GetFiliereByIdAsync(id);
            return filiere;
        }

        public async Task UpdateFiliereAsync(Filiere filiere)
        {
            await filiereRepertory.UpdateFiliereAsync(filiere);
        }
    }
}
