using EmagApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagApi.Core.ServiceProvider.Interface
{
    public interface IProfesseurServices
    {
        Task<List<Professeur>> GetAll();
        Task<Professeur> GetById(int id);
        Task Add (Professeur professeur); 
        Task Delete(int id);
        Task Update(Professeur professeur);
    }
}
