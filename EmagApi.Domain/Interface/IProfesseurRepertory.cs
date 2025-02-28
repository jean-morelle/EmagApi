using EmagApi.Domain.Models;

namespace EmagApi.Domain.Interface
{
    public interface IProfesseurRepertory
    {
        Task<List<Professeur>> GetAllProfesseursAsync();
        Task<Professeur> GetProfesseurByIdAsync(int id);
        Task AddProfesseurAsync(Professeur professeur);
        Task DeleteProfesseurAsync(int id);
        Task UpdateProfesseurAsync(Professeur professeur);
    }
}
