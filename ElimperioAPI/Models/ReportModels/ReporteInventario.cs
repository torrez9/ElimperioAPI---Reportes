using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ElImperioReportes.Models
{
    public class ProductoInventario
{
    public string NombreProducto { get; set; }
    public int UnidadesEnStock { get; set; }
}

public class ReporteInventario
{
    public List<ProductoInventario> Inventario { get; set; }
    public DateTime Fecha { get; set; }
}
}
