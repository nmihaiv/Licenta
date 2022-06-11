using CatalogCarti.API.Db;
using CatalogCarti.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogCarti.API.Controllers
{
    //In acest controller construim toate endpoint-urile pentru catalogul de carti.
    [Route("api/[controller]")]
    [ApiController]
    public class CartiController : ControllerBase
    {
        private readonly CatalogCartiContext _cartiContext;

        public CartiController(CatalogCartiContext catalogCartiContext)
        {
            _cartiContext = catalogCartiContext;
        }

        private bool CarteExistenta(int id)
        {
            return _cartiContext.Carti.Any(c => c.Id == id);
        }



        //GET: api/AfiseazaToateCartile
        [HttpGet("AfisareCarti")]
        public async Task<ActionResult<IEnumerable<Carte>>> AfisareCarti()
        {
            return await _cartiContext.Carti.ToListAsync();
        }

        //GET: api/AfisareCarte/1
        [HttpGet("AfisareCarte/{id}")]
        public async Task<ActionResult<Carte>> AfisareCarte(int id)
        {
            Carte carte = await _cartiContext.Carti.FindAsync(id);

            if (carte == null)
                return NotFound();

            return carte;
        }

        //POST: api/AdaugaCarte 
        [HttpPost("AdaugaCarte")]
        public async Task<ActionResult<Carte>> AdaugaCarte(Carte carte)
        {
            _cartiContext.Carti.Add(carte);
            await _cartiContext.SaveChangesAsync();

            return CreatedAtAction("AfisareCarte", new { id = carte.Id }, carte);
        }

        //PUT: api/ModificaCarte/1
        [HttpPut("EditareCarte/{id}")]
        public async Task<IActionResult> EditareCarte(int id, Carte carte)
        {
            if (id != carte.Id)
                return BadRequest();
            
            _cartiContext.Entry(carte).State = EntityState.Modified;

            try
            {
                await _cartiContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException err)
            {
                if(!CarteExistenta(id))
                    return NotFound();
                else
                    throw err;
            }
            return NoContent();
        }
    }
}
