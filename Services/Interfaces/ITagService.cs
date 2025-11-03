using System;
using GerenciadorTarefas.Entities;
using GerenciadorTarefas.Infra.DTOs;

namespace GerenciadorTarefas.Services.Interfaces;

public interface ITagService
{
    List<TagDto> ObterTodos();
    TagDto? ObterPorId(int id);
    TagDto Adicionar(CriarTagDto novaTag);
    Tag? Atualizar(int id, Tag tagAtualizada);
    bool Remover(int id);
}
