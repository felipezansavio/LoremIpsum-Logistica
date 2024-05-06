using LoremIpsumLogistica2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoremIpsumLogistica2.Controllers
{
    
        [ApiController]
        [Route("api/[controller]")]
        public class EnderecoController : ControllerBase
        {
            private readonly ApplicationDbContext _context;

            public EnderecoController(ApplicationDbContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Endereco>>> GetEnderecos()
            {
                return await _context.Enderecos.ToListAsync();
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Endereco>> GetEndereco(int id)
            {
                var endereco = await _context.Enderecos.FindAsync(id);

                if (endereco == null)
                {
                    return NotFound();
                }

                return endereco;
            }

            [HttpPost]
            public async Task<ActionResult<Endereco>> PostEndereco(Endereco endereco)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.Enderecos.Add(endereco);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetEndereco), new { id = endereco.Id }, endereco);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> PutEndereco(int id, Endereco endereco)
            {
                if (id != endereco.Id)
                {
                    return BadRequest();
                }

                _context.Entry(endereco).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnderecoExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteEndereco(int id)
            {
                var endereco = await _context.Enderecos.FindAsync(id);
                if (endereco == null)
                {
                    return NotFound();
                }

                _context.Enderecos.Remove(endereco);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool EnderecoExists(int id)
            {
                return _context.Enderecos.Any(e => e.Id == id);
            }
        }
    
}
