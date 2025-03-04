using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagApi.Application.Dtos
{
    public class ReadSeanceDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ProfesseurId { get; set; }
        public string Lieu { get; set; } = string.Empty;
        public int NombreHeure { get; set; }
        public bool SeanceTenue { get; set; }
        public int TotalHeuresProfesseur { get; set; }
    }
}
