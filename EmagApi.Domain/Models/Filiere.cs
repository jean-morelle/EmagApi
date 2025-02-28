using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagApi.Domain.Models
{
    public class Filiere
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public List<Matiere> Matieres { get; set; } = new List<Matiere>();
    }
}
