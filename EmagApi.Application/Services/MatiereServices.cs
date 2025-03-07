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

        public async Task Add(Matiere matiere)
        {
            await matiereRepertory.Add(matiere);
        }

        public async Task Delete(int id)
        {
            await matiereRepertory.Delete(id);
        }

        public Task<IEnumerable<Matiere>> GetAll()
        {
            return matiereRepertory.GetAll();
        }

        public Task<Matiere> GetById(int id)
        {
            return matiereRepertory.GetById(id);
        }

        public async Task Update(Matiere matiere)
        {
            await matiereRepertory.Update(matiere);
        }
    }
}
