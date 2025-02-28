using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagApi.Domain.Models
{
    public class Professeur
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        public ChoixDuSexe Sexe { get; set; }
        public DateTime DateDeNaissance { get; set; }
        public string Adresse { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public string DernierDiplome { get; set; } = string.Empty;
        public List<Seance> Seances { get; set; } = new List<Seance>();

    }
}
