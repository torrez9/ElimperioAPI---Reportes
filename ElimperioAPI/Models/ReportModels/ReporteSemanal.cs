using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ElImperioReportes.Models
{
    public class ReporteSemanal
    {
        public decimal VentasTotales { get; set; }
        public int ProductosVendidos { get; set; }
        public int ClientesAtendidos { get; set; }
        public decimal PromedioVentasDiarias { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
