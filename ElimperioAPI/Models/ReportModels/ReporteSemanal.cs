using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ElImperioReportes.Models
{
    public class ReporteSemanal
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } // Deja que MongoDB genere este campo automáticamente.
        public int VentasTotales { get; set; }
        public int ProductosVendidos { get; set; }
        public int ClientesAtendidos { get; set; }
        public string Descripcion { get; set; }
        public double PromedioVentasDiarias { get; set; }
        public int Semana { get; set; }
        public int Año { get; set; }
    }
}
