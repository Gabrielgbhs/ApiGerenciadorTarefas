using GerenciadorTarefas.Entities;
using GerenciadorTarefas.Infra.DTOs;
using GerenciadorTarefas.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace GerenciadorTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
            
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public ActionResult<List<UsuarioDto>> GetAll()
        {
            return Ok(_usuarioService.ObterTodos());
        }
        [HttpGet("{id}")]
        public ActionResult<Usuario> GetById(int id)
        {
            var usuario = _usuarioService.ObterPorId(id);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        [HttpPost]
        public ActionResult<Usuario> Add(CriarUsuarioDto novoUsuario)
        {
            if (string.IsNullOrWhiteSpace(novoUsuario.Nome))
            {
                return BadRequest("O nome do usuário é obrigatório.");
            }
            if (string.IsNullOrWhiteSpace(novoUsuario.Email))
            {
                return BadRequest("O E-Mail do usuário é obrigatório.");
            }
            var usuarioCriado = _usuarioService.Adicionar(novoUsuario);
            return CreatedAtAction(nameof(GetById), new { id = usuarioCriado.Id }, usuarioCriado);
        }

        [HttpPut("{id}")]
        public ActionResult<Usuario> Update(int id, Usuario usuarioAtualizado)
        {
            if (string.IsNullOrWhiteSpace(usuarioAtualizado.Nome))
            {
                return BadRequest("O nome do usuário é obrigatório.");
            }
            if (string.IsNullOrWhiteSpace(usuarioAtualizado.Email))
            {
                return BadRequest("O E-Mail do usuário é obrigatório.");
            }
            var usuario = _usuarioService.Atualizar(id, usuarioAtualizado);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }
 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var sucesso = _usuarioService.Remover(id);
            if (!sucesso) return NotFound();
            return NoContent();
        }
    }
}
