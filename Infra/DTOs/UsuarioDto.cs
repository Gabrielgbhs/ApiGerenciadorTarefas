using System;

namespace GerenciadorTarefas.Infra.DTOs;

public class UsuarioDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;    
    public List<TarefaDto> Tarefas { get; set; } = new List<TarefaDto>();
}
