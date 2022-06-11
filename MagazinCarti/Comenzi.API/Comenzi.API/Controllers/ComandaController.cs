using Comenzi.API.Db;
using Comenzi.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Comenzi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComandaController : ControllerBase
    {
        private readonly ComandaContext _comandaContext;

        public ComandaController(ComandaContext comandaContext)
        {
            _comandaContext = comandaContext;
        }

        private bool ComandaInexistenta(int id)
        {
            return _comandaContext.Comanda.Any(e => e.Id == id);
        }

        // GET: api/AfiseazaComenzi
        [HttpGet("AfiseazaComenzi")]
        public async Task<ActionResult<IEnumerable<Comanda>>> AfiseazaComenzi()
        {
            return await _comandaContext.Comanda.ToListAsync();
        }

        // GET: api/AfiseazaComanda/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comanda>> AfiseazaComanda(int id)
        {
            Comanda comanda = await _comandaContext.Comanda.FindAsync(id);

            if (comanda == null)
            {
                return NotFound();
            }

            return comanda;
        }

        // PUT: api/ModificaComanda/5
        [HttpPut("ModificaComanda/{id}")]
        public async Task<IActionResult> ModificaComanda(int id, Comanda comanda)
        {
            if (id != comanda.Id)
                return BadRequest();

            _comandaContext.Entry(comanda).State = EntityState.Modified;

            try
            {
                await _comandaContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!ComandaInexistenta(id))
                    return NotFound();
                else
                    throw ex;
            }

            return NoContent();
        }

        // POST: api/AdaugaComanda
        [HttpPost("AdaugaComanda")]
        public async Task<ActionResult<Comanda>> AdaugaComanda(Comanda comanda)
        {
            _comandaContext.Comanda.Add(comanda);
            await _comandaContext.SaveChangesAsync();

            return CreatedAtAction("AfiseazaComanda", new { id = comanda.Id }, comanda);
        }

        // DELETE: api/Orders/5
        [HttpDelete("StergeComanda/{id}")]
        public async Task<IActionResult> StergeComanda(int id)
        {
            Comanda comanda = await _comandaContext.Comanda.FindAsync(id);
            if (comanda == null)
            {
                return NotFound();
            }

            _comandaContext.Comanda.Remove(comanda);
            await _comandaContext.SaveChangesAsync();

            return NoContent();
        }


    }
}
