// Program.cs
using GerenciadorTarefas.Infra.Mapping;
using GerenciadorTarefas.Infra.Repositories.Interfaces;
using GerenciadorTarefas.Services;
using GerenciadorTarefas.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using GerenciadorTarefas.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: MyAllowSpecificOrigins,
        policy =>
        {
            policy
                .WithOrigins("http://127.0.0.1:3000")   // FRONT-END LIBERADO
                .AllowAnyHeader()
                .AllowAnyMethod();
        }
    );
});

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

// ATIVA O CORS AQUI ✔
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
