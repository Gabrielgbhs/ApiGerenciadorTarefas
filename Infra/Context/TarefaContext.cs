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

        #region Relacionamentos
        modelBuilder.Entity<Tarefa>().HasOne(t => t.Detalhes).WithOne(d => d.Tarefa).HasForeignKey<DetalhesTarefa>(d => d.Id);
        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Tarefas)
            .WithOne(t => t.Usuario)
            .HasForeignKey(u => u.UsuarioId);
        #endregion
    }
}
