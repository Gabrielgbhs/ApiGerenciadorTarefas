using System;
using AutoMapper;
using GerenciadorTarefas.Entities;
using GerenciadorTarefas.Infra.DTOs;
using GerenciadorTarefas.Infra.Repositories.Interfaces;
using GerenciadorTarefas.Services.Interfaces;

namespace GerenciadorTarefas.Services;

public class TarefaService : ITarefaService
{
    private readonly IMapper _mapper;
    private readonly ITarefaRepository _tarefaRepository;
    public TarefaService(
        ITarefaRepository tarefaRepository,
        IMapper mapper)
        {
            _tarefaRepository = tarefaRepository;
            _mapper = mapper;
        }
    public List<TarefaDto> ObterTodos()
    {
        var tarefas = _tarefaRepository.ObterTodos().ToList();
        return _mapper.Map<List<TarefaDto>>(tarefas);
    }

    public Tarefa Adicionar(CriarTarefaDto tarefaDto)
    {
        var novaTarefa = new Tarefa
        {
            Titulo = tarefaDto.Titulo.ToUpper(),
            Descricao = tarefaDto.Descricao,
            Concluida = false,
            DataCriacao = DateTime.UtcNow,
            DataConclusao = DateTime.UtcNow,
            UsuarioId = tarefaDto.UsuarioId,
            Detalhes = tarefaDto.Detalhes != null ? new DetalhesTarefa
            {
                Id = tarefaDto.Id,
                Prioridade = tarefaDto.Detalhes.Prioridade,
                NotasAdicionais = tarefaDto.Detalhes.NotasAdicionais
            } : null
        };
        return _tarefaRepository.Adicionar(novaTarefa);
    }

    public Tarefa? ObterPorId(int id)
    {
        return _tarefaRepository.ObterPorId(id);
    }
}
