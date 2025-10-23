using System;

namespace GerenciadorTarefas.Infra.DTOs;

public class TarefaDto
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;    
    public DateTime DataCriacao { get; set; }
    public string NotasAdicionais { get; set; } = string.Empty;    
}
