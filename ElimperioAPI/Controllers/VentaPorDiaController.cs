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

        // Acción para obtener todas las ventas registradas en todos los días sin filtros
        [HttpGet("todas")]
        public async Task<IActionResult> GetTodasLasVentasPorDia()
        {
            try
            {
                var ventas = await _ventaPorDiaService.ObtenerAsync();

                if (ventas == null || !ventas.Any())
                {
                    return NotFound("No se encontraron registros de ventas diarias.");
                }

                return Ok(ventas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener las ventas diarias: {ex.Message}");
            }
        }

        // Acción para obtener las ventas por un día específico
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

        // Acción para crear un nuevo registro de venta diaria
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
