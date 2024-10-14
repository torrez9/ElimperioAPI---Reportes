using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ElImperioReportes.Models
{
    public class ProductoMasVendido
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string NombreProducto { get; set; } = null!;
        public int CantidadVendida { get; set; }
        public decimal IngresosGenerados { get; set; }
        public int Mes { get; set; }
        public int Año { get; set; }
    }
}
