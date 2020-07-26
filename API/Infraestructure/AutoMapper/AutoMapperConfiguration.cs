using AutoMapper;
using Database;
using Database.Models;
using DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Infraestructure.AutoMapper
{
    public class AutoMapperConfiguration  : Profile
    {
        public AutoMapperConfiguration()
        {
            ConfigureIngr();
            ConfigurePlt();
            ConfigureOrd();
            ConfigureMes();
        }

        private void ConfigureIngr()
        {
            CreateMap<Ingredientes, IngredientesDTO>().ReverseMap()
                            .ForMember(dest => dest.Id, opt => opt.Ignore());
        }

        private void ConfigurePlt()
        {
            CreateMap<Platos,PlatosDTO>().ReverseMap()
                            .ForMember(dest => dest.Id, opt => opt.Ignore());
        }

        private void ConfigureOrd()
        {
            CreateMap<Ordenes, OrdenesDTO>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }

        private void ConfigureMes()
        {
            CreateMap<Mesas,MesasDTO>().ReverseMap()
                                .ForMember(dest => dest.Id, opt => opt.Ignore());

        }
    }
}
