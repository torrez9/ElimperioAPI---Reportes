using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ElImperioReportes.Models
{
    public class BebidaMasVendida
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } // El Id que lo genere MongoDB automáticamente

        [BsonElement("NombreBebida")]
        public string NombreBebida { get; set; } = null!;

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
