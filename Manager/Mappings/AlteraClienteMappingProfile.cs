using System;
using AutoMapper;
using Core.Domain;
using Core.Shared.ModelViews;

namespace Manager.Mappings;

public class AlteraClienteMappingProfile : Profile
{
    public AlteraClienteMappingProfile()
    {
        CreateMap<AlteraCliente, Cliente>()
            .ForMember(nc => nc.Atulizacao, o => o.MapFrom(x => DateTime.Now))
            .ForMember(d => d.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date));
    }
}
