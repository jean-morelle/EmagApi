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
        public string Nom { get; set; } 

        public string Email { get; set; }

        public ICollection<Emargement>Emargements { get; set; }
      

    }
}
