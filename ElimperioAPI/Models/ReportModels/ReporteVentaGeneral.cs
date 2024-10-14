using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ElImperioReportes.Models
{
    public class VentaGeneral
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public decimal TotalVentas { get; set; }
        public int CantidadVentas { get; set; }
        public decimal Ganancias { get; set; }
        public int Mes { get; set; }
        public int Año { get; set; }
    }
}
