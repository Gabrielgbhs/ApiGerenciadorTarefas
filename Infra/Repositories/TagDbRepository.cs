using System;
using GerenciadorTarefas.Infra.Repositories.Interfaces;
using GerenciadorTarefas.Entities;
using GerenciadorTarefas.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorTarefas.Infra.Repositories;

public class TagDbRepository : ITagRepository
{

    private readonly TarefaContext _context;
    public TagDbRepository(TarefaContext context)
    {
        _context = context;
    }

    public Tag Adicionar(Tag novaTag)
    {
        _context.Tags.Add(novaTag);
        _context.SaveChanges();
        return novaTag;
    }

    public Tag? ObterPorId(int id)
    {
        return _context.Tags.FirstOrDefault(u => u.Id == id);
    }

    public List<Tag> ObterTodos()
    {
        return _context.Tags.ToList();
    }

    public Tag? Atualizar(int id, Tag tagAtualizada)
    {
        _context.Tags.Update(tagAtualizada);
        _context.SaveChanges();
        return tagAtualizada;
    }
    
    public bool Remover(int id) {
        var tagParaDeletar = ObterPorId(id);
        if (tagParaDeletar == null) return false;
        _context.Tags.Remove(tagParaDeletar);
        _context.SaveChanges();
        return true;
    }
}
