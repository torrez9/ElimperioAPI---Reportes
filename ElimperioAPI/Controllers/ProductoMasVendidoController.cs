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

        // Acción para obtener todos los productos más vendidos sin filtros
        [HttpGet("todos")]
        public async Task<IActionResult> GetTodosLosProductosMasVendidos()
        {
            try
            {
                var productos = await _productoMasVendidoService.ObtenerAsync();

                if (productos == null || !productos.Any())
                {
                    return NotFound("No se encontraron registros de productos más vendidos.");
                }

                return Ok(productos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los productos más vendidos: {ex.Message}");
            }
        }

        // Acción para obtener el producto más vendido por mes y año
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

        // Acción para crear un nuevo registro de producto más vendido
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
