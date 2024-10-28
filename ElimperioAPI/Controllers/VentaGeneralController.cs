using ElimperioAPI.Services;
using ElImperioReportes.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElimperioAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaGeneralController : ControllerBase
    {
        private readonly VentaGeneralService _ventaGeneralService;

        public VentaGeneralController(VentaGeneralService ventaGeneralService)
        {
            _ventaGeneralService = ventaGeneralService;
        }

        // Acción para obtener todas las ventas generales sin filtros
        [HttpGet("todas")]
        public async Task<IActionResult> GetTodasLasVentasGenerales()
        {
            try
            {
                var ventas = await _ventaGeneralService.ObtenerAsync();

                if (ventas == null || !ventas.Any())
                {
                    return NotFound("No se encontraron registros de ventas generales.");
                }

                return Ok(ventas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener las ventas generales: {ex.Message}");
            }
        }

        // Acción para obtener las ventas generales por mes y año
        [HttpGet("{mes}/{año}")]
        public async Task<IActionResult> GetVentaGeneral(int mes, int año)
        {
            var ventas = await _ventaGeneralService.ObtenerPorMesYAñoAsync(mes, año);

            if (ventas == null || ventas.Count == 0)
            {
                return NotFound($"No se encontraron ventas generales para el mes {mes} y el año {año}.");
            }

            return Ok(ventas);
        }

        // Acción para crear un nuevo registro de venta general
        [HttpPost]
        public async Task<IActionResult> CrearVentaGeneral([FromBody] VentaGeneral nuevaVentaGeneral)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _ventaGeneralService.CrearAsync(nuevaVentaGeneral);
            return CreatedAtAction(nameof(GetVentaGeneral), new { mes = nuevaVentaGeneral.Mes, año = nuevaVentaGeneral.Año }, nuevaVentaGeneral);
        }
    }
}
