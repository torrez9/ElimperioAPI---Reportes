using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ElImperioReportes.Models
{
    public class VentaPorDia
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public decimal TotalVentas { get; set; }
        public int CantidadVentas { get; set; }
        public DateTime Fecha { get; set; }
    }
}
