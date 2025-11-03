// Program.cs teste2
using GerenciadorTarefas.Infra.Mapping;
using GerenciadorTarefas.Infra.Repositories.Interfaces;
using GerenciadorTarefas.Services;
using GerenciadorTarefas.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using GerenciadorTarefas.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<GerenciadorTarefas.Infra.Context.TarefaContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<ITarefaService, TarefaService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ITagService, TagService>();

builder.Services.AddScoped<ITarefaRepository, TarefaDbRepostory>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioDbRepository>();
builder.Services.AddScoped<ITagRepository, TagDbRepository>();


builder.Services.AddAutoMapper(typeof(MappingProfile));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
