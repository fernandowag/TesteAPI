using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteAPI.Data;
using TesteAPI.Models;
using TesteAPI.Repositories.RepositoriesInterfaces;

namespace TesteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViloesController : ControllerBase
    {
        private readonly HeroiContext _context;

        public ViloesController(HeroiContext context)
        {
            _context = context;
            
        }

        // GET: api/Viloes
        [HttpGet]
        public  async Task<IEnumerable<Vilao>> GetViloes()
        {
            var result = await _context.Viloes.ToListAsync<Vilao>();
            return result;

        }



        // GET: api/Viloes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetVilao(int id)
        {
            var vilao = await _context.Viloes.FindAsync(id);

            if (vilao == null)
            {
                return NotFound();
            }

            //return vilao;

            //var nome = vilao.Nome;

            var customizedReturn = new {

                nome = vilao.Nome,
                armas = vilao.Armas,
                teste = "teste" 
            
            };

            return customizedReturn;

        }

        // PUT: api/Viloes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVilao(int id, Vilao vilao)
        {
            if (id != vilao.Id)
            {
                return BadRequest();
            }

            _context.Entry(vilao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VilaoExists(id))
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

        // POST: api/Viloes
        [HttpPost]
        public async Task<ActionResult<Vilao>> PostVilao(Vilao vilao)
        {
            _context.Viloes.Add(vilao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVilao", new { id = vilao.Id }, vilao);
        }

        // DELETE: api/Viloes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vilao>> DeleteVilao(int id)
        {
            var vilao = await _context.Viloes.FindAsync(id);
            if (vilao == null)
            {
                return NotFound();
            }

            _context.Viloes.Remove(vilao);
            await _context.SaveChangesAsync();

            return vilao;
        }

        private bool VilaoExists(int id)
        {
            return _context.Viloes.Any(e => e.Id == id);
        }
    }
}
