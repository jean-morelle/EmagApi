using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagApi.Core.Models
{
    public class Matiere
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public ICollection<Emargement> Emargements { get; set; }
    }
}
