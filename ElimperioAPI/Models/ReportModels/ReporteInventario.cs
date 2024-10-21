using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ElImperioReportes.Models
{
    public class ReporteInventario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();  // Se generará automáticamente

        [BsonElement("ProductosTotales")]
        public int ProductosTotales { get; set; }

        [BsonElement("ProductosEnStock")]
        public int ProductosEnStock { get; set; }

        [BsonElement("ProductosAgotados")]
        public int ProductosAgotados { get; set; }

        [BsonElement("Descripcion")]
        public string Descripcion { get; set; }

        [BsonElement("FechaActualizacion")]
        public DateTime FechaActualizacion { get; set; }
    }
}
