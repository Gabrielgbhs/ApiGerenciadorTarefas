using System;
using GerenciadorTarefas.Infra.Repositories.Interfaces;
using GerenciadorTarefas.Entities;
using GerenciadorTarefas.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorTarefas.Infra.Repositories;

public class TarefaDbRepostory : ITarefaRepository
{
    private readonly TarefaContext _context;
    public TarefaDbRepostory(TarefaContext context)
    {
        _context = context;
    }

    public Tarefa Adicionar(Tarefa novaTarefa)
    {
        novaTarefa.DataCriacao = DateTime.UtcNow;
        _context.Tarefas.Add(novaTarefa);
        _context.SaveChanges();
        return novaTarefa;
    }

    public Tarefa? ObterPorId(int id)
    {
        return _context.Tarefas.FirstOrDefault(c => c.Id == id);
    }
    
    public List<Tarefa> ObterTodos()
    {
        return _context.Tarefas.Include(t => t.Usuario).Include(t => t.Detalhes).ToList();
    }
}
