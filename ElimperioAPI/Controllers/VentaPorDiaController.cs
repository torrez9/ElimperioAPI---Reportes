using ElimperioAPI.Services;
using ElImperioReportes.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElimperioAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaPorDiaController : ControllerBase
    {
        private readonly VentaPorDiaService _ventaPorDiaService;

        public VentaPorDiaController(VentaPorDiaService ventaPorDiaService)
        {
            _ventaPorDiaService = ventaPorDiaService;
        }

        [HttpGet("{fecha}")]
        public async Task<IActionResult> GetVentaPorDia(DateTime fecha)
        {
            var ventas = await _ventaPorDiaService.ObtenerPorFechaAsync(fecha);

            if (ventas == null || ventas.Count == 0)
            {
                return NotFound($"No se encontraron ventas para la fecha {fecha.ToShortDateString()}.");
            }

            return Ok(ventas);
        }

        [HttpPost]
        public async Task<IActionResult> CrearVentaPorDia([FromBody] VentaPorDia nuevaVentaPorDia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _ventaPorDiaService.CrearAsync(nuevaVentaPorDia);
            return CreatedAtAction(nameof(GetVentaPorDia), new { fecha = nuevaVentaPorDia.Fecha }, nuevaVentaPorDia);
        }
    }
}
