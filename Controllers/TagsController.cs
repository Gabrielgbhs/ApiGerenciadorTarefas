using GerenciadorTarefas.Entities;
using GerenciadorTarefas.Infra.DTOs;
using GerenciadorTarefas.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
                    
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public ActionResult<List<TagDto>> GetAll()
        {
            return Ok(_tagService.ObterTodos());
        }
        [HttpGet("{id}")]
        public ActionResult<Tag> GetById(int id)
        {
            var tag = _tagService.ObterPorId(id);
            if (tag == null) return NotFound();
            return Ok(tag);
        }

        [HttpPost]
        public ActionResult<Tag> Add(CriarTagDto novaTag)
        {
            if (string.IsNullOrWhiteSpace(novaTag.Nome))
            {
                return BadRequest("O nome da tag é obrigatório.");
            }
            var tagCriada = _tagService.Adicionar(novaTag);
            return CreatedAtAction(nameof(GetById), new { id = tagCriada.Id }, tagCriada);
        }

        [HttpPut("{id}")]
        public ActionResult<Tag> Update(int id, Tag tagAtualizada)
        {
            if (string.IsNullOrWhiteSpace(tagAtualizada.Nome))
            {
                return BadRequest("O nome da tag é obrigatório.");
            }
            var tag = _tagService.Atualizar(id, tagAtualizada);
            if (tag == null) return NotFound();
            return Ok(tag);
        }
 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var sucesso = _tagService.Remover(id);
            if (!sucesso) return NotFound();
            return NoContent();
        }
    }
}
