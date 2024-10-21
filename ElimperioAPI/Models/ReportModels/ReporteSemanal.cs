using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ElImperioReportes.Models
{
    public class ReporteSemanal
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } // Deja que MongoDB genere este campo automáticamente.

        [BsonElement("Ventas totales")]
        public int VentasTotales { get; set; }

        [BsonElement("Productos vendidos")]
        public int ProductosVendidos { get; set; }

        [BsonElement("Clientes atendidos")]
        public int ClientesAtendidos { get; set; }
        public string Descripcion { get; set; }

        [BsonElement("Promedio de ventas diarias")]
        public double PromedioVentasDiarias { get; set; }
        public int Semana { get; set; }

        [BsonElement("Año")]
        public int Año { get; set; }
    }
}
