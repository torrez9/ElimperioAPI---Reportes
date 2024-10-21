using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ElImperioReportes.Models
{
    public class BebidaMasVendida
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } // El Id que lo genere MongoDB automáticamente

        [BsonElement("Nombre de la Bebida")]
        public string NombreBebida { get; set; } = null!;

        [BsonElement("Cantidad de Bebidas vendidas")]
        public int CantidadVendida { get; set; }

        [BsonElement("Ganancias")]
        public decimal IngresosGenerados { get; set; }

        [BsonElement("Meses")]
        public int Mes { get; set; }

        [BsonElement("Año de bebidas")]
        public int Año { get; set; }
    }
}
