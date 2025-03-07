using EmagApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagApi.Domain.Interface
{
    public interface IMatiereRepertory
    {
        Task<IEnumerable<Matiere>> GetAll();
        Task<Matiere> GetById(int id);
        Task Add(Matiere matiere);
        Task Update(Matiere matiere);
        Task Delete(int id);
    }
}
