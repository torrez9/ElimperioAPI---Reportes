using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ElImperioReportes.Models
{
    public class ReporteInventario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();  // Se generará automáticamente

        [BsonElement("Productos Totales")]
        public int ProductosTotales { get; set; }

        [BsonElement("Productos en el inventario")]
        public int ProductosEnStock { get; set; }

        [BsonElement("Productos agotados")]
        public int ProductosAgotados { get; set; }

        [BsonElement("Nombre de los productos")]
        public string Descripcion { get; set; }

        [BsonElement("Fecha de los productos")]
        public DateTime FechaActualizacion { get; set; }
    }
}
