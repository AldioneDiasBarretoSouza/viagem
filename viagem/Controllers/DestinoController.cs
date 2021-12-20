using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using viagem.Models;
using vigem;

namespace viagem.Controllers
{
    [Route("api/destinos")]
    [ApiController]
    public class DestinoController : Controller
    {

        private readonly ApplicationDbContext _context;

        public DestinoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Destino> GetDestinos()
        {
            return _context.Destinos;
        }

        [HttpPost]
        public IActionResult CriarDestino([FromBody] Destino request)
        {
            if(request == null)
            {
                return BadRequest();
            }

            _context.Destinos.Add(request);
            _context.SaveChanges();

            return CreatedAtAction("GetDestino", new { id = request.ID }, request);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarDestino(int id, [FromBody] Destino request)
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

            var destino = _context.Destinos.SingleOrDefaultAsync(d => d.ID == id).Result;

            if (destino == null)
            {
                return BadRequest();
            }

            _context.Destinos.Remove(destino);
            _context.SaveChanges();

            return Ok(destino);
        }

    }
}
