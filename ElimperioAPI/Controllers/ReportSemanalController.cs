using ElimperioAPI.Services;
using ElImperioReportes.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ElimperioAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportSemanalController : ControllerBase
    {
        private readonly ReportSemanalService _reportSemanalService;

        public ReportSemanalController(ReportSemanalService reportSemanalService)
        {
            _reportSemanalService = reportSemanalService;
        }

        // Acción para obtener el reporte semanal por semana y año
        [HttpGet("{semana}/{año}")]
        public async Task<IActionResult> GetReporteSemanal(int semana, int año)
        {
            try
            {
                var reporte = await _reportSemanalService.ObtenerPorSemanaYAñoAsync(semana, año);

                if (reporte == null)
                {
                    return NotFound($"No se encontró un reporte semanal para la semana {semana} del año {año}.");
                }

                return Ok(reporte);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener el reporte semanal: {ex.Message}");
            }
        }

        // Acción para crear un nuevo reporte semanal
        [HttpPost]
        public async Task<IActionResult> CrearReporteSemanal([FromBody] ReporteSemanal nuevoReporte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _reportSemanalService.CrearReporteSemanalAsync(nuevoReporte);
                return CreatedAtAction(nameof(GetReporteSemanal), new { semana = nuevoReporte.Semana, año = nuevoReporte.Año }, nuevoReporte);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el reporte semanal: {ex.Message}");
            }
        }
    }
}
