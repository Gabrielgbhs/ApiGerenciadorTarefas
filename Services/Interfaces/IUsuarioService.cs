using System;
using GerenciadorTarefas.Entities;
using GerenciadorTarefas.Infra.DTOs;

namespace GerenciadorTarefas.Services.Interfaces;

public interface IUsuarioService
{
    List<UsuarioDto> ObterTodos();
    UsuarioDto? ObterPorId(int id);
    UsuarioDto Adicionar(CriarUsuarioDto novoUsuario);
    Usuario? Atualizar(int id, Usuario usuarioAtualizado);
    bool Remover(int id);
}
