using AutoMapper;
using EmagApi.Application.Dtos;
using EmagApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmagApi.Application.Profils
{
    public class ProfesseurProfils:Profile
    {
        public ProfesseurProfils()
        {
            CreateMap<Professeur,AddProfesseurDto>();
            CreateMap<AddProfesseurDto, Professeur>();
            CreateMap<Professeur,ProfesseurDto>();
            CreateMap<ProfesseurDto,Professeur>();
        }
    }
}
