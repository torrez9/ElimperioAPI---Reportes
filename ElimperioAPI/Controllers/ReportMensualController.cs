using ElimperioAPI.Services;
using ElImperioReportes.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ElimperioAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportMensualController : ControllerBase
    {
        private readonly ReportMensualService _reportMensualService;

        public ReportMensualController(ReportMensualService reportMensualService)
        {
            _reportMensualService = reportMensualService;
        }

        // Acción para obtener el reporte mensual por mes y año
        [HttpGet("{mes}/{año}")]
        public async Task<IActionResult> GetReporteMensual(int mes, int año)
        {
            try
            {
                var reportes = await _reportMensualService.ObtenerPorMesYAñoAsync(mes, año);

                if (reportes == null || !reportes.Any())
                {
                    return NotFound($"No se encontró un reporte mensual para el mes {mes} y el año {año}.");
                }

                return Ok(reportes);
            }
            catch (Exception ex)
            {
                // Manejo de errores genéricos
                return StatusCode(500, $"Error al obtener el reporte mensual: {ex.Message}");
            }
        }

        // Acción para crear un nuevo reporte mensual
        [HttpPost]
        public async Task<IActionResult> CrearReporteMensual([FromBody] ReporteMensual nuevoReporte)
        {
            // Validamos el modelo antes de proceder
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Llamamos al servicio para crear el reporte
                await _reportMensualService.CrearAsync(nuevoReporte);

                return CreatedAtAction(nameof(GetReporteMensual), new { mes = nuevoReporte.Mes, año = nuevoReporte.Año }, nuevoReporte);
            }
            catch (Exception ex)
            {
                // Manejo de errores genéricos
                return StatusCode(500, $"Error al crear el reporte mensual: {ex.Message}");
            }
        }
    }
}
