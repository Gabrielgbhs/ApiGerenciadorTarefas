using System;

namespace GerenciadorTarefas.Entities;
/*
CREATE TABLE "TB_TAREFAS_TAGS" (
"id_tarefa" INT NOT NULL,
"id_tag" INT NOT NULL,
PRIMARY KEY ("id_tarefa", "id_tag"),
CONSTRAINT "fk_tarefatag_tarefa" FOREIGN KEY ("id_tarefa") REFERENCES
"TB_TAREFAS"("id_tarefa") ON DELETE CASCADE,
CONSTRAINT "fk_tarefatag_tag" FOREIGN KEY ("id_tag") REFERENCES
"TB_TAGS"("id_tag") ON DELETE CASCADE
);
*/
public class TarefaTag
{
    public int IdTarefa { get; set; }
    public int IdTag { get; set; }
    public Tarefa? Tarefa { get; set; }
    public Tag? Tag { get; set; }
}
