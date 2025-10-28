using System;
using GerenciadorTarefas.Entities;

namespace GerenciadorTarefas.Infra.Repositories.Interfaces;

public interface ITarefaRepository
{
    List<Tarefa> ObterTodos();
    Tarefa? ObterPorId(int id);
    Tarefa Adicionar(Tarefa novaTarefa);
    Tarefa? Atualizar(int id, Tarefa tarefaAtualizada);
    bool Remover(int id);
}
