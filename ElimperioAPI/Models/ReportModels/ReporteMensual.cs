using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class ReporteMensual
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

    [BsonElement("VentasTotales")]
    public double VentasTotales { get; set; }

    [BsonElement("ProductosVendidos")]
    public int ProductosVendidos { get; set; }

    [BsonElement("ClientesAtendidos")]
    public int ClientesAtendidos { get; set; }

    [BsonElement("Descripcion")]
    public string Descripcion { get; set; }

    [BsonElement("PromedioVentasDiarias")]
    public double PromedioVentasDiarias { get; set; }

    [BsonElement("Mes")]
    public int Mes { get; set; }

    [BsonElement("Año")]
    public int Año { get; set; }
}
