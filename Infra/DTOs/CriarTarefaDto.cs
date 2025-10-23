using System;
using System.ComponentModel.DataAnnotations;
using GerenciadorTarefas.Entities;

namespace GerenciadorTarefas.Infra.DTOs;

public class CriarTarefaDto
{
    [Required]
    public int UsuarioId { get; set; }
    [Required]
    public int Id { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O titulo da tarefa deve ter entre 3 e 100 caracteres.")]
    public string Titulo { get; set; } = string.Empty;
    [Required]
    [StringLength(500, ErrorMessage = "A descrição da tarefa deve ter até 500 caracteres.")]
    public string Descricao { get; set; } = string.Empty;    
    [Required]
    public DateTime DataCriacao { get; set; }
    public DateTime DataConclusao { get; set; }
    [Required]
    public bool Concluida { get; set; }
    public CriarDetalhesTarefaDto? Detalhes { get; set; }
}
