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
