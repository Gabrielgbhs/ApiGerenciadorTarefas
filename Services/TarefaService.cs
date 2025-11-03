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

    public TarefaDto Adicionar(CriarTarefaDto tarefaDto)
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
        return _mapper.Map<TarefaDto>(_tarefaRepository.Adicionar(novaTarefa));
    }

    public TarefaTagDto AssociarTag(CriarTarefaTagDto tarefaTagDto)
    {
        var novaTarefaTag = new TarefaTag
        {
            IdTag = tarefaTagDto.IdTag,
            IdTarefa = tarefaTagDto.IdTarefa,
        };
        return _mapper.Map<TarefaTagDto>(_tarefaRepository.AssociarTag(novaTarefaTag));
    }

    public Tarefa? ObterPorId(int id)
    {
        return _tarefaRepository.ObterPorId(id);
    }

    public Tarefa? Atualizar(int id, Tarefa tarefaAtualizada)
    {
        if (id != tarefaAtualizada.Id)
        {
            return null;
        }
        return _tarefaRepository.Atualizar(id, tarefaAtualizada);
    }

    public Tarefa? Concluir(int id)
    {
        var tarefa = _tarefaRepository.ObterPorId(id);
        if (tarefa == null)
        {
            return null;
        }
        tarefa.Concluida = true;
        return _tarefaRepository.Atualizar(id, tarefa);
    }

    public bool Remover(int id)
    {
        var tarefa = _tarefaRepository.ObterPorId(id);
        if (tarefa != null)
        {
            return _tarefaRepository.Remover(id);
        }
        return false;
    }
}
