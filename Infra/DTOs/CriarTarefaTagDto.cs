using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorTarefas.Infra.DTOs;

public class CriarTarefaTagDto
{
    [Required]
    public int IdTarefa { get; set; }
    [Required]
    public int IdTag { get; set; }
}
