using Microsoft.VisualBasic;
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
        public double NombreHeure { get; set; }
        public bool SeanceTenue { get; set; }
        public DateTime CommencerA { get; set; }
        public DateTime TerminerA { get; set; }
        public List<SeanceMatiere> SeanceMatieres { get; set; } = new List<SeanceMatiere>();
        // Méthode pour calculer le nombre d'heures entre CommencerA et TerminerA sans TimeSpan
        public double CalculerNombreHeures()
        {
            // Calculer la différence entre TerminerA et CommencerA en minutes
            double differenceEnMinutes = (TerminerA - CommencerA).TotalMinutes;

            // Convertir la différence en heures
            return differenceEnMinutes / 60;
        }
    }
}
