using System;
using AutoMapper;
using GerenciadorTarefas.Entities;
using GerenciadorTarefas.Infra.DTOs;

namespace GerenciadorTarefas.Infra.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Tarefa, TarefaDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Titulo))
            .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
            .ForMember(dest => dest.DataCriacao, opt => opt.MapFrom(src => src.DataCriacao))
            .ForMember(dest => dest.NotasAdicionais, opt => opt.MapFrom(src => src.Detalhes != null ? src.Detalhes.NotasAdicionais : string.Empty));

        CreateMap<Tarefa, CriarTarefaDto>();
        CreateMap<DetalhesTarefa, CriarDetalhesTarefaDto>();
            
    }
}
