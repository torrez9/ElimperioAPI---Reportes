using ElimperioAPI.Services;
using ElImperioReportes.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElimperioAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BebidaMasVendidaController : ControllerBase
    {
        private readonly BebidaMasVendidaService _bebidaMasVendidaService;

        public BebidaMasVendidaController(BebidaMasVendidaService bebidaMasVendidaService)
        {
            _bebidaMasVendidaService = bebidaMasVendidaService;
        }

        [HttpGet]
        public async Task<List<BebidaMasVendida>> Get() =>
            await _bebidaMasVendidaService.ObtenerAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<BebidaMasVendida>> Get(string id)
        {
            var bebida = await _bebidaMasVendidaService.ObtenerAsync(id);
            if (bebida is null)
            {
                return NotFound();
            }
            return bebida;
        }

        [HttpPost]
        public async Task<IActionResult> Post(BebidaMasVendida nuevaBebida)
        {
            await _bebidaMasVendidaService.CrearAsync(nuevaBebida);
            return CreatedAtAction(nameof(Get), new { id = nuevaBebida.Id }, nuevaBebida);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, BebidaMasVendida bebidaActualizada)
        {
            var bebida = await _bebidaMasVendidaService.ObtenerAsync(id);
            if (bebida is null)
            {
                return NotFound();
            }

            bebidaActualizada.Id = bebida.Id;
            await _bebidaMasVendidaService.ActualizarAsync(id, bebidaActualizada);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var bebida = await _bebidaMasVendidaService.ObtenerAsync(id);
            if (bebida is null)
            {
                return NotFound();
            }

            await _bebidaMasVendidaService.EliminarAsync(id);
            return NoContent();
        }
    }
}
