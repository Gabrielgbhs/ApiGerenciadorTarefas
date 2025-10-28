using GerenciadorTarefas.Entities;
using GerenciadorTarefas.Infra.DTOs;
using GerenciadorTarefas.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        
        private readonly ITarefaService _tarefaService;

        public TarefasController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        [HttpGet]
        public ActionResult<List<TarefaDto>> GetAll()
        {
            return Ok(_tarefaService.ObterTodos());
        }
        [HttpGet("{id}")]
        public ActionResult<Tarefa> GetById(int id)
        {
            var tarefa = _tarefaService.ObterPorId(id);
            if (tarefa == null) return NotFound();
            return Ok(tarefa);
        }

        [HttpPost]
        public ActionResult<Tarefa> Add(CriarTarefaDto novaTarefa)
        {
            if (string.IsNullOrWhiteSpace(novaTarefa.Titulo))
            {
                return BadRequest("O titulo da tarefa é obrigatório.");
            }
            if (string.IsNullOrWhiteSpace(novaTarefa.Descricao))
            {
                return BadRequest("A descrição da tarefa é obrigatória.");
            }
            var tarefaCriada = _tarefaService.Adicionar(novaTarefa);
            return CreatedAtAction(nameof(GetById), new { id = tarefaCriada.Id }, tarefaCriada);
        }

        [HttpPut("{id}")]
        public ActionResult<Tarefa> Update(int id, Tarefa tarefaAtualizada)
        {
            if (string.IsNullOrWhiteSpace(tarefaAtualizada.Titulo))
            {
                return BadRequest("O titulo da tarefa é obrigatório.");
            }
            if (string.IsNullOrWhiteSpace(tarefaAtualizada.Descricao))
            {
                return BadRequest("A descrição da tarefa é obrigatória.");
            }
            var tarefa = _tarefaService.Atualizar(id, tarefaAtualizada);
            if (tarefa == null) return NotFound();
            return Ok(tarefa);
        }

        [HttpPut("{id}/concluir")]
        public ActionResult<Tarefa> Concluir(int id)
        {
            var tarefa = _tarefaService.Concluir(id);
            if (tarefa == null) return NotFound();
            return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var sucesso = _tarefaService.Remover(id);
            if (!sucesso) return NotFound();
            return NoContent();
        }
    }
}
