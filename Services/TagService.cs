using System;
using AutoMapper;
using GerenciadorTarefas.Entities;
using GerenciadorTarefas.Infra.DTOs;
using GerenciadorTarefas.Infra.Repositories.Interfaces;
using GerenciadorTarefas.Services.Interfaces;

namespace GerenciadorTarefas.Services;

public class TagService : ITagService
{
    private readonly IMapper _mapper;
    private readonly ITagRepository _tagRepository;
    public TagService(
        ITagRepository tagRepository,
        IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }
    public List<TagDto> ObterTodos()
    {
        var tag = _tagRepository.ObterTodos().ToList();
        return _mapper.Map<List<TagDto>>(tag);
    }

    public TagDto Adicionar(CriarTagDto tagDto)
    {
        var novaTag = new Tag
        {
            Nome = tagDto.Nome,
        };
        return _mapper.Map<TagDto>(_tagRepository.Adicionar(novaTag));
    }

    public TagDto? ObterPorId(int id)
    {
        return _mapper.Map<TagDto>(_tagRepository.ObterPorId(id));
    }

    public Tag? Atualizar(int id, Tag tagAtualizada)
    {
        if (id != tagAtualizada.Id)
        {
            return null;
        }
        return _tagRepository.Atualizar(id, tagAtualizada);
    }

    public bool Remover(int id)
    {
        var tag = _tagRepository.ObterPorId(id);
        if (tag != null)
        {
            return _tagRepository.Remover(id);
        }
        return false;
    }
}
