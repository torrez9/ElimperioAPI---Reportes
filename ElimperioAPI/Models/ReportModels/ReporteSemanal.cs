using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ElImperioReportes.Models
{
    public class ReporteSemanal
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } // Deja que MongoDB genere este campo automáticamente.

        [BsonElement("VentasTotales")]
        public int VentasTotales { get; set; }

        [BsonElement("ProductosVendidos")]
        public int ProductosVendidos { get; set; }

        [BsonElement("ClientesAtendidos")]
        public int ClientesAtendidos { get; set; }

        [BsonElement("Descripcion")]
        public string Descripcion { get; set; }

        [BsonElement("PromedioVentasDiarias")]
        public double PromedioVentasDiarias { get; set; }

        [BsonElement("Semana")]
        public int Semana { get; set; }

        [BsonElement("Año")]
        public int Año { get; set; }
    }
}
