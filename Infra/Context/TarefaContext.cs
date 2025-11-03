using System;
using Microsoft.EntityFrameworkCore;
using GerenciadorTarefas.Entities;

 
namespace GerenciadorTarefas.Infra.Context;

public class TarefaContext : DbContext
{
    public TarefaContext(DbContextOptions<TarefaContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Tarefa> Tarefas { get; set; }
    public DbSet<DetalhesTarefa> DetalhesTarefas { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<TarefaTag> TarefaTags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("TB_USUARIOS");
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Id).HasColumnName("id_usuario");
            entity.Property(u => u.Nome).HasColumnName("nome_usuario").HasMaxLength(100).IsRequired();
            entity.Property(u => u.Email).HasColumnName("email_usuario").HasMaxLength(150).IsRequired();
        });

        modelBuilder.Entity<Tarefa>(entity =>
        {
            entity.ToTable("TB_TAREFAS");
            entity.HasKey(t => t.Id);
            entity.Property(t => t.Id).HasColumnName("id_tarefa");
            entity.Property(t => t.Titulo).HasColumnName("titulo_tarefa").HasMaxLength(100).IsRequired();
            entity.Property(t => t.Descricao).HasColumnName("descricao_tarefa").HasMaxLength(500);
            entity.Property(t => t.DataCriacao).HasColumnName("data_criacao").IsRequired();
            entity.Property(t => t.DataConclusao).HasColumnName("data_conclusao");
            entity.Property(t => t.Concluida).HasColumnName("concluida");
            entity.Property(t => t.UsuarioId).HasColumnName("id_usuario").IsRequired();
        });

        modelBuilder.Entity<DetalhesTarefa>(entity =>
        {
            entity.ToTable("TB_DETALHES_TAREFA");
            entity.HasKey(d => d.Id);
            entity.Property(d => d.Id).HasColumnName("id_tarefa");
            entity.Property(d => d.Prioridade).HasColumnName("prioridade").IsRequired();
            entity.Property(d => d.NotasAdicionais).HasColumnName("notas_adicionais");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.ToTable("TB_TAGS");
            entity.HasKey(t => t.Id);
            entity.Property(t => t.Id).HasColumnName("id_tag");
            entity.Property(t => t.Nome).HasColumnName("nome_tag").HasMaxLength(50).IsRequired();
            entity.HasIndex(t => t.Nome).IsUnique();
        });

        modelBuilder.Entity<TarefaTag>(entity =>
        {
            entity.ToTable("TB_TAREFAS_TAGS");
            entity.HasKey(tt => new { tt.IdTarefa, tt.IdTag });
            entity.Property(t => t.IdTarefa).HasColumnName("id_tarefa");
            entity.Property(t => t.IdTag).HasColumnName("id_tag");
        });

        #region Relacionamentos
        modelBuilder.Entity<Tarefa>().HasOne(t => t.Detalhes).WithOne(d => d.Tarefa).HasForeignKey<DetalhesTarefa>(d => d.Id);
        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Tarefas)
            .WithOne(t => t.Usuario)
            .HasForeignKey(u => u.UsuarioId);

        modelBuilder.Entity<Tarefa>()
            .HasMany(t => t.TarefaTags)
            .WithOne(tt => tt.Tarefa)
            .HasForeignKey(tt => tt.IdTarefa)
            .HasConstraintName("fk_tarefatag_tarefa");

        // 2. Relacionamento 1:N -> Pedido (1) : (N) PedidoProdutos
        modelBuilder.Entity<Tag>()
            .HasMany(t => t.TarefaTags)
            .WithOne(tt => tt.Tag)
            .HasForeignKey(tt => tt.IdTag)
            .HasConstraintName("fk_tarefatag_tag");
        #endregion
    }
}
