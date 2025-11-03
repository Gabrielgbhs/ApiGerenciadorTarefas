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

    public TarefaTag AssociarTag(TarefaTag novaTarefaTag)
    {
        _context.TarefaTags.Add(novaTarefaTag);
        _context.SaveChanges();
        return novaTarefaTag;
    }

    public Tarefa? ObterPorId(int id)
    {
        return _context.Tarefas.FirstOrDefault(c => c.Id == id);
    }

    public List<Tarefa> ObterTodos()
    {
        return _context.Tarefas.Include(t => t.Usuario).Include(t => t.Detalhes).ToList();
    }

    public Tarefa? Atualizar(int id, Tarefa tarefaAtualizada)
    {
        _context.Tarefas.Update(tarefaAtualizada);
        _context.SaveChanges();
        return tarefaAtualizada;
    }
    
    public bool Remover(int id) {
        var tarefaParaDeletar = ObterPorId(id);
        if (tarefaParaDeletar == null) return false;
        _context.Tarefas.Remove(tarefaParaDeletar);
        _context.SaveChanges();
        return true;
    }
}
