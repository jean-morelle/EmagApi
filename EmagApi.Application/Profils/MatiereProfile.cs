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
    public class MatiereProfile:Profile
    {
        public MatiereProfile()
        {
            CreateMap<Matiere,MatiereDto>();
            CreateMap<MatiereDto, Matiere>();
            CreateMap<Matiere,AddMatiereDto>();
            CreateMap<AddMatiereDto, Matiere>();
        }
    }
}
