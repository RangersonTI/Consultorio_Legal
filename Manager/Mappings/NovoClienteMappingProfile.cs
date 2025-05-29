using System;
using AutoMapper;
using Core.Domain;
using Core.Shared.ModelViews;

namespace Manager.Mappings;

public class NovoClienteMappingProfile : Profile
{
    public NovoClienteMappingProfile()
    {
        CreateMap<NovoCliente, Cliente>()
            .ForMember(nc => nc.Criacao, o => o.MapFrom(x => DateTime.Now))
            .ForMember(d => d.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date));
    }
}
