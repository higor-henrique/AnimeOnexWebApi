using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AnimeOnex.EnvelopeJson.Logic;
using AnimeOnex.ModelData.Logic;

namespace AnimeOnex.Business.Mappers
{
    public class DomainToViewModelMappingProfile: Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuario, UsuarioEnvelopeJson>();
        }
        
    }
}