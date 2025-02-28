
using EmagApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagApi.Application.Dtos
{
    public class ProfesseurDto
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        public ChoixDuSexe Sexe { get; set; }
        public DateTime DateDeNaissance { get; set; }
        public string Adresse { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public string DernierDiplome { get; set; } = string.Empty;
    }
}
