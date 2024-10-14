using ElimperioAPI.Services;
using ElImperioReportes.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElimperioAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventarioController : ControllerBase
    {
        private readonly InventarioService _inventarioService;

        public InventarioController(InventarioService inventarioService)
        {
            _inventarioService = inventarioService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInventario(string id)
        {
            var reporte = await _inventarioService.ObtenerAsync(id);

            if (reporte == null)
            {
                return NotFound($"No se encontró el reporte de inventario con ID: {id}.");
            }

            return Ok(reporte);
        }

        [HttpPost]
        public async Task<IActionResult> CrearReporteInventario([FromBody] ReporteInventario nuevoReporte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _inventarioService.CrearAsync(nuevoReporte);
            return CreatedAtAction(nameof(GetInventario), new { id = nuevoReporte.Id }, nuevoReporte);
        }
    }
}
