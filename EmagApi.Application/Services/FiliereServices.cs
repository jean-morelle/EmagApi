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

        public async Task Add(Filiere filiere)
        {
          await filiereRepertory.Add(filiere);
        }

        public async Task Delete(int id)
        {
           await filiereRepertory.Delete(id);
        }

        public Task<IEnumerable<Filiere>> GetAll()
        {
            return filiereRepertory.GetAll();
        }

        public Task<Filiere> GetById(int id)
        {
           return filiereRepertory.GetById(id);
        }

        public async Task Update(Filiere filiere)
        {
           await filiereRepertory.Update(filiere);
        }
    }
}
