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
    internal class SeanceProfile:Profile
    {
        public SeanceProfile()
        {
            CreateMap<Seance,SeanceDto>();
            CreateMap<SeanceDto,Seance>();
            CreateMap<Seance, AddSeanceDto>();
            CreateMap<AddSeanceDto, Seance>();
        }
    }
}
