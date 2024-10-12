using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ElImperioReportes.Models
{
    public class ProductoMasVendido
    {
        public string NombreProducto { get; set; }
        public int CantidadVendida { get; set; }
    }

    public class ReporteProductosMasVendidos
    {
        public List<ProductoMasVendido> Productos { get; set; }
        public DateTime Fecha { get; set; }
    }
}
