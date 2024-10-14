using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ElImperioReportes.Models
{
    public class BebidaMasVendida
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } // El Id puede ser nulo para que lo genere MongoDB automáticamente
        public string NombreBebida { get; set; } = null!;
        public int CantidadVendida { get; set; }
        public decimal IngresosGenerados { get; set; }
        public int Mes { get; set; }
        public int Año { get; set; }
    }
}
