using EmagApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagApi.Domain.Interface
{
    public interface ISeanceMatiereRepertory
    {
        Task<IEnumerable<SeanceMatiere>> GetAllInformationOfProfesseur(int professeurId);
    }
}
