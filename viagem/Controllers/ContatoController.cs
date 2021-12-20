using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using viagem.Models;
using vigem;

namespace viagem.Controllers
{
    [Route("api/contatos")]
    [ApiController]
    public class ContatoController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ContatoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Contato> GetContatos()
        {
            return _context.Contatos;
        }
        
        [HttpPost]
        public IActionResult CriarContato([FromBody] Contato request)
        {
            if(request == null)
            {
                return BadRequest();
            }

            _context.Contatos.Add(request);
            _context.SaveChanges();

            return CreatedAtAction("GetDestino", new { id = request.ID }, request);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarContato(int id, [FromBody] Contato request)
        {
            if (request.ID != id)
            {
                return BadRequest();
            }

            _context.Entry(request).State = EntityState.Modified;
            _context.SaveChanges();

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarDestino(int id)
        {

            var contato = _context.Contatos.SingleOrDefaultAsync(d => d.ID == id).Result;

            if (contato == null)
            {
                return BadRequest();
            }

            _context.Contatos.Remove(contato);
            _context.SaveChanges();

            return Ok(contato);
        }

    }
}
