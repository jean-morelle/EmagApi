﻿using EmagApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagApi.Application.Dtos
{
    public class AddEmargementDto
    {
        public int ProfesseurId { get; set; }
        public int MatiereId { get; set; }
        public int FiliereId { get; set; }
        public int SiteId { get; set; }
        public DateTime HeureDebut { get; set; }
        public DateTime HeureFin { get; set; }
    }
}
