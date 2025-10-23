using System;

namespace GerenciadorTarefas.Entities;
/*
CREATE TABLE "TB_USUARIOS" (
"id_usuario" SERIAL PRIMARY KEY,
"nome_usuario" VARCHAR(100) NOT NULL,
"email_usuario" VARCHAR(150) NOT NULL UNIQUE
);
*/
public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public ICollection<Tarefa> Tarefas { get; set; } = new List<Tarefa>();
}
