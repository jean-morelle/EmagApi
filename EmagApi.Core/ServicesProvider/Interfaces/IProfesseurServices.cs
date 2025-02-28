﻿

using EmagApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagApi.Core.ServicesProvider.Interfaces
{
    public interface IProfesseurServices
    {
        Task<List<Professeur>> GetAllProfesseursAsync();
        Task<Professeur> GetProfesseurByIdAsync(int id);
        Task AddProfesseurAsync(Professeur professeur);
        Task DeleteProfesseurAsync(int id);
        Task UpdateProfesseurAsync(Professeur professeur);
    }
}
