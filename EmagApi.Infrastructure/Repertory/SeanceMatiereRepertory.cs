using EmagApi.Domain.Interface;
using EmagApi.Domain.Models;
using EmagApi.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagApi.Infrastructure.Repertory
{
    public class SeanceMatiereRepertory : ISeanceMatiereRepertory
    {
        private readonly ApplicationDbContext dbContext;

        public SeanceMatiereRepertory(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<IEnumerable<SeanceMatiere>> GetAllInformationOfProfesseur(int professeurId)
        {
            throw new NotImplementedException();
        }
    }
}

