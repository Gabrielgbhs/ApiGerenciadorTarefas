using System;
using GerenciadorTarefas.Entities;
using GerenciadorTarefas.Infra.DTOs;

namespace GerenciadorTarefas.Services.Interfaces;

public interface ITarefaService
{
    List<TarefaDto> ObterTodos();
    Tarefa? ObterPorId(int id);
    Tarefa Adicionar(CriarTarefaDto novaTarefa);
}
