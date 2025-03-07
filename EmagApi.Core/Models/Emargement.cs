using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagApi.Core.Models
{
    public class Emargement
    {
        public int Id { get; set; }
        public int ProfesseurId { get; set; }
        public Professeur Professeur { get; set; }
        public int MatiereId { get; set; }
        public Matiere? Matiere { get; set; }
        public int FiliereId { get; set; }
        public Filiere Filiere { get; set; }
        public int SiteId { get; set; }
        public Site Site { get; set; }
        public DateTime HeureDebut { get; set; }
        public DateTime HeureFin { get; set; }
        public TimeSpan GetDuree() => HeureFin - HeureDebut;
    }

   
}
