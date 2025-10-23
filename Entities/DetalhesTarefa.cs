using System;

namespace GerenciadorTarefas.Entities;
/*
CREATE TABLE "TB_DETALHES_TAREFA" (
"id_tarefa" INT PRIMARY KEY, -- Mesma chave primária de Tarefas
"prioridade" INT NOT NULL DEFAULT 0, -- Ex: 0=Baixa, 1=Média, 2=Alta
"notas_adicionais" TEXT NULL,
CONSTRAINT "fk_tarefa_detalhes" FOREIGN KEY ("id_tarefa") REFERENCES
"TB_TAREFAS"("id_tarefa") ON DELETE CASCADE -- Se deletar a tarefa, deleta os detalhes
);
*/
public class DetalhesTarefa
{
    public int Id { get; set; }
    public int Prioridade { get; set; }
    public string NotasAdicionais { get; set; } = string.Empty;
    public Tarefa? Tarefa { get; set; }
}
