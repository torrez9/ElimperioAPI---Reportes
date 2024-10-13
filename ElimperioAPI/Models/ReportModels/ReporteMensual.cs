using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class ReporteMensual
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
    public double VentasTotales { get; set; }
    public int ProductosVendidos { get; set; }
    public int ClientesAtendidos { get; set; }
    public string Descripcion { get; set; }
    public double PromedioVentasDiarias { get; set; }
    public int Mes { get; set; }
    public int Año { get; set; }
}
