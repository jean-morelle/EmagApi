using EmagApi.Domain.Interface;
using EmagApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
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

        public ProfesseurServices(IProfesseurRepertory professeurRepertory )
        {
            this.professeurRepertory = professeurRepertory;
        }

        public async Task Add(Professeur professeur)
        {
         await professeurRepertory.Add(professeur);
        }

        public  async Task Delete(int id)
        {
          await professeurRepertory.Delete( id );
        }

        public Task<IEnumerable<Professeur>> GetAll()
        {
            return professeurRepertory.GetAll();
        }

        public Task<Professeur> GetById(int id)
        {
            return professeurRepertory.GetById( id );
        }

        public async Task Update(Professeur professeur)
        {
            await professeurRepertory.Update( professeur );
        }
    }
}
