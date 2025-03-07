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
    public class EmargementProfile:Profile
    {
        public EmargementProfile()
        {
            CreateMap<Emargement,EmargementDto>();
            CreateMap<EmargementDto,Emargement>();
            CreateMap<Emargement,AddEmargementDto>();
            CreateMap<AddEmargementDto, Emargement>();
        }
    }
}
