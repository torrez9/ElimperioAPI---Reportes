using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ElImperioReportes.Models
{
    public class ReporteVentasPorDia
    {
        public decimal TotalVentasHoy { get; set; }
        public int NumeroTransacciones { get; set; }
        public decimal PromedioVentasPorTransaccion { get; set; }
        public DateTime Fecha { get; set; }
    }
}
