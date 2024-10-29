using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ElImperioReportes.Models
{
    public class PlatoMasVendido
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("NombrePlato")]
        public string NombrePlato { get; set; }

        [BsonElement("CantidadVendida")]
        public int CantidadVendida { get; set; }

        [BsonElement("FechaReporte")]
        public DateTime FechaReporte { get; set; }
    }
}
