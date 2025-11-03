using System;

namespace GerenciadorTarefas.Entities;
/*
CREATE TABLE "TB_TAGS" (
"id_tag" SERIAL PRIMARY KEY,
"nome_tag" VARCHAR(50) NOT NULL UNIQUE
);
*/
public class Tag
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public ICollection<TarefaTag> TarefaTags { get; set; } = new List<TarefaTag>();
}
