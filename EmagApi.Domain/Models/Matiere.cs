using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagApi.Domain.Models
{
    public class Matiere
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
      //  public int FiliereId { get; set; }
       // public Filiere Filiere { get; set; }
        public List<SeanceMatiere> SeanceMatieres { get; set; } = new List<SeanceMatiere>();
    }
}
