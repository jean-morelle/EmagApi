﻿using EmagApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagApi.Domain.Interface
{
    public interface IMatiereRepertory
    {
        Task<IEnumerable<Matiere>> GetAllMatiere();
        Task<Matiere> GetMatiereByIdAsync(int id);
        Task AddMatiereAsync(Matiere matiere);
        Task UpdateMatiereAsync(Matiere matiere);
        Task DeleteMatiereAsync(int id);
    }
}
