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

        //Obtener todos sin filtros
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var bebidas = await _bebidaMasVendidaService.ObtenerAsync();
            if (bebidas == null || !bebidas.Any())
            {
                return NotFound("No se encontraron bebidas más vendidas.");
            }

            return Ok(bebidas);
        }

        //Obtener todos por ID
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

        //Crear Bebidas
        [HttpPost]
        public async Task<IActionResult> Post(BebidaMasVendida nuevaBebida)
        {
            await _bebidaMasVendidaService.CrearAsync(nuevaBebida);
            return CreatedAtAction(nameof(Get), new { id = nuevaBebida.Id }, nuevaBebida);
        }

        //Editar por ID
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

        //Eliminar
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
