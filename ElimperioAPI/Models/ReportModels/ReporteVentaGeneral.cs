using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ElImperioReportes.Models
{
    public class ReporteVentaGeneral
    {
        public decimal TotalVentasAcumuladas { get; set; }
        public int NumeroTotalTransacciones { get; set; }
        public decimal PromedioVentasPorTransaccion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
