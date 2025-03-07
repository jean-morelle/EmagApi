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
    public class FiliereProfile:Profile
    {
        public FiliereProfile()
        {
            CreateMap<Filiere,FiliereDto>();
            CreateMap<FiliereDto,Filiere>();
            CreateMap<Filiere,AddFiliereDto>();
            CreateMap<AddFiliereDto,Filiere>();
        }
    }
}
