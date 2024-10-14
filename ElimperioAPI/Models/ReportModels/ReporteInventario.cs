using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ElImperioReportes.Models
{
    public class ReporteInventario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();  // Se generará automáticamente
        public int ProductosTotales { get; set; }
        public int ProductosEnStock { get; set; }
        public int ProductosAgotados { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
