using System;
using GerenciadorTarefas.Infra.Repositories.Interfaces;
using GerenciadorTarefas.Entities;
using GerenciadorTarefas.Infra.Context;
using Microsoft.EntityFrameworkCore;


namespace GerenciadorTarefas.Infra.Repositories.Interfaces;

public class UsuarioDbRepository : IUsuarioRepository
{
    private readonly TarefaContext _context;
    public UsuarioDbRepository(TarefaContext context)
    {
        _context = context;
    }

    public Usuario Adicionar(Usuario novoUsuario)
    {
        _context.Usuarios.Add(novoUsuario);
        _context.SaveChanges();
        return novoUsuario;
    }

    public Usuario? ObterPorId(int id)
    {
        return _context.Usuarios.Include(t => t.Tarefas).FirstOrDefault(u => u.Id == id);
    }

    public List<Usuario> ObterTodos()
    {
        return _context.Usuarios.ToList();
    }

    public Usuario? Atualizar(int id, Usuario usuarioAtualizado)
    {
        _context.Usuarios.Update(usuarioAtualizado);
        _context.SaveChanges();
        return usuarioAtualizado;
    }
    
    public bool Remover(int id) {
        var usuarioParaDeletar = ObterPorId(id);
        if (usuarioParaDeletar == null) return false;
        _context.Usuarios.Remove(usuarioParaDeletar);
        _context.SaveChanges();
        return true;
    }
}
