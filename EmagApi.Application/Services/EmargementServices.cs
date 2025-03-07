using EmagApi.Domain.Interface;
using EmagApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagApi.Application.Services
{
    public class EmargementServices:IEmargementServices
    {
        private readonly IEmargementRepertory emargementRepertory;

        public EmargementServices(IEmargementRepertory emargementRepertory)
        {
            this.emargementRepertory = emargementRepertory;
        }

        public async Task Add(Emargement emargement)
        {
            await emargementRepertory.Add(emargement);
        }
        public async Task Delete(int id)
        {
           await emargementRepertory.Delete(id);
        }

        public Task<IEnumerable<Emargement>> GetAll()
        {
            return emargementRepertory.GetAll();
        }

        public Task<Emargement> GetById(int id)
        {
            return emargementRepertory.GetById(id);
        }

        public async Task<Emargement?> GetEmargementByDetails(int professeurId, DateTime heureDebut, DateTime heureFin, int? matiereId = null, int? siteId = null)
        {
            return await emargementRepertory.GetEmargementByDetails(professeurId,heureDebut,heureFin,matiereId);
        }

        public async Task Update(Emargement emargement)
        {
           await emargementRepertory.Update(emargement);
        }
    }
}
