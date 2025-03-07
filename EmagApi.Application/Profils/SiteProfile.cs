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
    public class SiteProfile:Profile
    {
        public SiteProfile()
        {
            CreateMap<Site,SiteDto>();
            CreateMap<SiteDto,Site>();
            CreateMap<Site,AddSiteDto>();
            CreateMap<AddSiteDto,Site>();
        }
    }
}
