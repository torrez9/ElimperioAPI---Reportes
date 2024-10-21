using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ElImperioReportes.Models
{
    public class VentaPorDia
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Total ventas")]
        public decimal TotalVentas { get; set; }

        [BsonElement("Cantidad de ventas")]
        public int CantidadVentas { get; set; }

        [BsonElement("Fecha de ventas")]
        public DateTime Fecha { get; set; }
    }
}
