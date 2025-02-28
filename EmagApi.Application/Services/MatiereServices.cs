using EmagApi.Domain.Interface;
using EmagApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagApi.Application.Services
{
    public class MatiereServices:IMatiereServices
    {
        private readonly IMatiereRepertory matiereRepertory;

        public MatiereServices(IMatiereRepertory matiereRepertory)
        {
            this.matiereRepertory = matiereRepertory;
        }

        public async Task AddMatiereAsync(Matiere matiere)
        {
            await matiereRepertory.AddMatiereAsync(matiere);
        }

        public async Task DeleteMatiereAsync(int id)
        {
            await matiereRepertory.DeleteMatiereAsync(id);
        }

        public async Task<IEnumerable<Matiere>> GetAllMatieresAsync()
        {
            var matiere = await matiereRepertory.GetAllMatiere();
            return matiere;
        }

        public async Task<Matiere> GetMatiereByIdAsync(int id)
        {
            var matiere = await matiereRepertory.GetMatiereByIdAsync(id);
            return matiere;
        }

        public async Task UpdateMatiereAsync(Matiere matiere)
        {
            await matiereRepertory.UpdateMatiereAsync(matiere);
        }
    }
}
