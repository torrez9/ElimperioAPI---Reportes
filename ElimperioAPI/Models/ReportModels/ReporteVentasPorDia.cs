using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ElImperioReportes.Models
{
    public class VentaPorDia
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("TotalVentas")]
        public decimal TotalVentas { get; set; }

        [BsonElement("CantidadVentas")]
        public int CantidadVentas { get; set; }

        [BsonElement("Fecha")]
        public DateTime Fecha { get; set; }
    }
}
