using EmagApi.Domain.Models;

namespace EmagApi.Domain.Interface
{
    public interface IProfesseurRepertory
    {
        Task<IEnumerable<Professeur>> GetAll();
        Task<Professeur> GetById(int id);
        Task Add(Professeur professeur);
        Task Delete(int id);
        Task Update(Professeur professeur);
    }
}
