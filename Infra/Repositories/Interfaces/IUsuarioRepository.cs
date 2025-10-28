using System;
using GerenciadorTarefas.Entities;

namespace GerenciadorTarefas.Infra.Repositories.Interfaces;

public interface IUsuarioRepository
{
    List<Usuario> ObterTodos();
    Usuario? ObterPorId(int id);
    Usuario Adicionar(Usuario novoUsuario);
    Usuario? Atualizar(int id, Usuario usuarioAtualizada);
    bool Remover(int id);
}
