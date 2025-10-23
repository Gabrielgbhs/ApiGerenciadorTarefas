using System;
using System.ComponentModel.DataAnnotations;
using GerenciadorTarefas.Entities;

namespace GerenciadorTarefas.Infra.DTOs;

public class CriarDetalhesTarefaDto
{
    [Required]
    public int Id { get; set; }
    [Required]
    public int Prioridade { get; set; }
    public string NotasAdicionais { get; set; } = string.Empty;
}
