using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorTarefas.Infra.DTOs;

public class CriarUsuarioDto
{
    [Required]
    public int Id { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do usuário deve ter entre 3 e 100 caracteres.")]
    
    public string Nome { get; set; } = string.Empty;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;    
}
