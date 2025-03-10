using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagApi.Domain.Models
{
    public class Admin
    {
       // [DatabaseGenerated(databaseGeneratedOption:)]
        [Column("id")]
        public int Id { get; set; }
        [Column("Nom-D-Utilisateur")]
        [MaxLength(100)]
        public string? Nom { get; set; }
        [Column("Mot-de-passe")]
        [MaxLength(100)]
        public string? PassWord { get; set; }
        [Column("Role")]
        [MaxLength(20)]
        public string? Role { get; set; }
    }
}
