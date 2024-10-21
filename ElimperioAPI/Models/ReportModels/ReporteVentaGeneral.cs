using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ElImperioReportes.Models
{
    public class VentaGeneral
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("TotalVentas")]
        public decimal TotalVentas { get; set; }

        [BsonElement("CantidadVentas")]
        public int CantidadVentas { get; set; }

        [BsonElement("Ganancias")]
        public decimal Ganancias { get; set; }

        [BsonElement("Mes")]
        public int Mes { get; set; }

        [BsonElement("Año")]
        public int Año { get; set; }
    }
}
