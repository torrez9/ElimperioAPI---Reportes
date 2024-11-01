using ElimperioAPI.Services.ReportServices;
using ElImperioReportes.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElimperioAPI.Controllers.ReportControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatoMasVendidoController : ControllerBase
    {
        private readonly PlatoMasVendidoService _platoMasVendidoService;

        public PlatoMasVendidoController(PlatoMasVendidoService platoMasVendidoService)
        {
            _platoMasVendidoService = platoMasVendidoService;
        }

        // Obtener todos los platos más vendidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlatoMasVendido>>> ObtenerAsync()
        {
            var platos = await _platoMasVendidoService.ObtenerAsync();
            return Ok(platos);
        }

        // Obtener un plato más vendido por ID
        [HttpGet("{id:length(24)}", Name = "ObtenerPlatoMasVendido")]
        public async Task<ActionResult<PlatoMasVendido>> ObtenerAsync(string id)
        {
            var plato = await _platoMasVendidoService.ObtenerAsync(id);

            if (plato == null)
            {
                return NotFound();
            }

            return Ok(plato);
        }

        // Crear un nuevo plato más vendido
        [HttpPost]
        public async Task<ActionResult> CrearAsync(PlatoMasVendido platoMasVendido)
        {
            await _platoMasVendidoService.CrearAsync(platoMasVendido);
            return CreatedAtRoute("ObtenerPlatoMasVendido", new { id = platoMasVendido.Id }, platoMasVendido);
        }

        // Actualizar un plato más vendido
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> ActualizarAsync(string id, PlatoMasVendido platoMasVendido)
        {
            var existingPlato = await _platoMasVendidoService.ObtenerAsync(id);

            if (existingPlato == null)
            {
                return NotFound();
            }

            platoMasVendido.Id = existingPlato.Id;
            await _platoMasVendidoService.ActualizarAsync(id, platoMasVendido);

            return NoContent();
        }

        // Eliminar un plato más vendido
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> EliminarAsync(string id)
        {
            var plato = await _platoMasVendidoService.ObtenerAsync(id);

            if (plato == null)
            {
                return NotFound();
            }

            await _platoMasVendidoService.EliminarAsync(id);
            return NoContent();
        }


    }
}
