using System;

namespace GerenciadorTarefas.Entities;
/*
CREATE TABLE "TB_TAREFAS" (
"id_tarefa" SERIAL PRIMARY KEY,
"titulo_tarefa" VARCHAR(100) NOT NULL,
"descricao_tarefa" VARCHAR(500) NULL,
"data_criacao" TIMESTAMP WITH TIME ZONE NOT NULL,
"data_conclusao" TIMESTAMP WITH TIME ZONE NULL,
"concluida" BOOLEAN NOT NULL DEFAULT false,
"id_usuario" INT NOT NULL, -- Chave Estrangeira para Usuario
CONSTRAINT "fk_usuario_tarefa" FOREIGN KEY ("id_usuario") REFERENCES
"TB_USUARIOS"("id_usuario")
);
*/
public class Tarefa
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;    
    public DateTime DataCriacao { get; set; }
    public DateTime DataConclusao { get; set; }
    public bool Concluida { get; set; }
    public int UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }
    public DetalhesTarefa? Detalhes { get; set; }
}
