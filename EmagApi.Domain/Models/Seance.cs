using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagApi.Domain.Models
{
    public class Seance
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ProfesseurId { get; set; }
        public Professeur? Professeur { get; set; }
        public string Lieu { get; set; } = string.Empty;
        public int NombreHeure { get; set; }
        public bool SeanceTenue { get; set; }
        public List<SeanceMatiere> SeanceMatieres { get; set; } = new List<SeanceMatiere>();
    }
}
