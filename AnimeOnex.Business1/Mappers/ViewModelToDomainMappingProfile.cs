using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AnimeOnex.ModelData.Logic;
using AnimeOnex.EnvelopeJson.Logic;

namespace AnimeOnex.Business.Mappers
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UsuarioEnvelopeJson, Usuario>();
        }
    }
}