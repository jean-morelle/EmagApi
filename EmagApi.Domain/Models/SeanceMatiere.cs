using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagApi.Domain.Models
{
    public class SeanceMatiere
    {
        public int Id { get; set; }
        public int SeanceId { get; set; }
        public Seance? Seance { get; set; }
        public int MatiereId { get; set; }
        public Matiere? Matiere { get; set; }
        public TimeSpan CommencerA { get; set; }
        public TimeSpan TerminerA { get; set; }
    }
}
