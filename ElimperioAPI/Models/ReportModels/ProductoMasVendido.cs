using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ElImperioReportes.Models
{
    public class ProductoMasVendido
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("NombreProducto")]
        public string NombreProducto { get; set; } = null!;

        [BsonElement("CantidadVendida")]
        public int CantidadVendida { get; set; }

        [BsonElement("IngresosGenerados")]
        public decimal IngresosGenerados { get; set; }

        [BsonElement("Mes")]
        public int Mes { get; set; }

        [BsonElement("Año")]
        public int Año { get; set; }
    }
}
