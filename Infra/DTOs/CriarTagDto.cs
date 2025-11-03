using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorTarefas.Infra.DTOs;

public class CriarTagDto
{
    [Required]
    public int Id { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome da tag deve ter entre 3 e 50 caracteres.")]
    public string Nome { get; set; } = string.Empty;
}
