using System;
using AutoMapper;
using GerenciadorTarefas.Entities;
using GerenciadorTarefas.Infra.DTOs;
using GerenciadorTarefas.Infra.Repositories.Interfaces;
using GerenciadorTarefas.Services.Interfaces;
 
namespace GerenciadorTarefas.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IMapper _mapper;
    private readonly IUsuarioRepository _usuarioRepository;
    public UsuarioService(
        IUsuarioRepository usuarioRepository,
        IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }
    public List<UsuarioDto> ObterTodos()
    {
        var usuarios = _usuarioRepository.ObterTodos().ToList();
        return _mapper.Map<List<UsuarioDto>>(usuarios);
    }

    public UsuarioDto Adicionar(CriarUsuarioDto usuarioDto)
    {
        var novoUsuario = new Usuario
        {
            Nome = usuarioDto.Nome,
            Email = usuarioDto.Email,
        };
        return _mapper.Map<UsuarioDto>(_usuarioRepository.Adicionar(novoUsuario));
    }

    public UsuarioDto? ObterPorId(int id)
    {
        return _mapper.Map<UsuarioDto>(_usuarioRepository.ObterPorId(id));
    }

    public Usuario? Atualizar(int id, Usuario usuarioAtualizado)
    {
        if (id != usuarioAtualizado.Id)
        {
            return null;
        }
        return _usuarioRepository.Atualizar(id, usuarioAtualizado);
    }

    public bool Remover(int id)
    {
        var usuario = _usuarioRepository.ObterPorId(id);
        if (usuario != null)
        {
            return _usuarioRepository.Remover(id);
        }
        return false;
    }
}
