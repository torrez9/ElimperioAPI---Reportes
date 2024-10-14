using ElimperioAPI.Services;
using ElImperioReportes.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElimperioAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoMasVendidoController : ControllerBase
    {
        private readonly ProductoMasVendidoService _productoMasVendidoService;

        public ProductoMasVendidoController(ProductoMasVendidoService productoMasVendidoService)
        {
            _productoMasVendidoService = productoMasVendidoService;
        }

        [HttpGet("{mes}/{año}")]
        public async Task<IActionResult> GetProductoMasVendido(int mes, int año)
        {
            var producto = await _productoMasVendidoService.ObtenerPorMesYAñoAsync(mes, año);

            if (producto == null || producto.Count == 0)
            {
                return NotFound($"No se encontraron productos más vendidos para el mes {mes} y el año {año}.");
            }

            return Ok(producto);
        }

        [HttpPost]
        public async Task<IActionResult> CrearProductoMasVendido([FromBody] ProductoMasVendido nuevoProducto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _productoMasVendidoService.CrearAsync(nuevoProducto);
            return CreatedAtAction(nameof(GetProductoMasVendido), new { mes = nuevoProducto.Mes, año = nuevoProducto.Año }, nuevoProducto);
        }
    }
}
