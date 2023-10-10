using AutoMapper;
using drugovich.autopecas.application.Features.Grupos.Commands.CreateGrupo;
using drugovich.autopecas.application.Features.Grupos.Commands.UpdateGrupo;
using drugovich.autopecas.application.Features.Grupos.Queries.GetGrupoById;
using drugovich.autopecas.application.Features.Grupos.Queries.GetGrupoList;
using drugovich.autopecas.application.InputModels;
using drugovich.autopecas.application.ViewModels;
using drugovich.autopecas.core;
using drugovich.autopecas.core.Extensions;

namespace drugovich.autopecas.application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Grupo, GrupoViewModel>();
        CreateMap<CreateGrupoInputModel, Grupo>();
        CreateMap<Grupo, CreateGrupoDto>();
        CreateMap<Grupo, GrupoListVm>(); 
        CreateMap<Grupo, GrupoVm>();
        CreateMap<UpdateGrupoCommand, Grupo>();

        CreateMap<Cliente, ClienteViewModel>()
            .ForMember(dest => dest.GrupoNome, 
                opt => opt.MapFrom(src => src.Grupo.Nome));
        CreateMap<CreateClienteInputModel, Cliente>();
        
        CreateMap<Gerente, GerenteViewModel>()
            .ForMember(dest => dest.Nivel, 
                opt => opt.MapFrom(src => src.Nivel.GetDescription()));
        CreateMap<CreateGerenteInputModel, Gerente>();
        
    }
}