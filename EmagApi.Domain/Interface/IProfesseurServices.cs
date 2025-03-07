using EmagApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagApi.Domain.Interface
{
    public interface IProfesseurServices
    {
        Task<IEnumerable<Professeur>> GetAll();
        Task<Professeur> GetById(int id);
        Task Add(Professeur professeur);
        Task Delete(int id);
        Task Update(Professeur professeur);
    }
}
