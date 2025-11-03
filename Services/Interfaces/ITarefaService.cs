using System;
using GerenciadorTarefas.Entities;
using GerenciadorTarefas.Infra.DTOs;

namespace GerenciadorTarefas.Services.Interfaces;

public interface ITarefaService
{
    List<TarefaDto> ObterTodos();
    Tarefa? ObterPorId(int id);
    TarefaDto Adicionar(CriarTarefaDto novaTarefa);
    TarefaTagDto AssociarTag(CriarTarefaTagDto tarefaTagDto);
    Tarefa? Atualizar(int id, Tarefa tarefaAtualizada);
    Tarefa? Concluir(int id);
    bool Remover(int id);
}
