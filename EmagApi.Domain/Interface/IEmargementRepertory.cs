﻿using EmagApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagApi.Domain.Interface
{
    public interface IEmargementRepertory
    {
        Task<Emargement?> GetEmargementByDetails(int professeurId, DateTime heureDebut, DateTime heureFin, int? matiereId = null, int? siteId = null);

       Task<IEnumerable<Emargement>> GetAll();
        Task<Emargement> GetById(int id);
        Task Add(Emargement emargement);
        Task Update(Emargement emargement);
        Task Delete(int id);
        // verifier s il y a un conflit d emargement
        Task<bool> HasConflictingEmargement(int professeurId, DateTime heureDebut, DateTime heureFin);
    }
}
