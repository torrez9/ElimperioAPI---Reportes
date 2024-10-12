using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ElImperioReportes.Models
{
    public class ReporteMensual
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } // Cambia el tipo a string para ObjectId
        public decimal VentasTotales { get; set; }
        public int ProductosVendidos { get; set; }
        public int ClientesAtendidos { get; set; }
        public string Descripcion { get; set; }
        public decimal PromedioVentasDiarias { get; set; }
        public int Mes { get; set; }
        public int Año { get; set; }
    }
}
