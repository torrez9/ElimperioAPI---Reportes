using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ElImperioReportes.Models
{
    public class BebidaMasVendida
    {
        public string NombreBebida { get; set; }
        public int CantidadVendida { get; set; }
    }
    public class ReporteBebidasMasVendidas
    {
        public List<BebidaMasVendida> Bebidas { get; set; }
        public DateTime Fecha { get; set; }
    }
}
