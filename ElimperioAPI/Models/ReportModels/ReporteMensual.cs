using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class ReporteMensual
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

    [BsonElement("ventas Totales")]
    public double VentasTotales { get; set; }

    [BsonElement("Productos vendidos")]
    public int ProductosVendidos { get; set; }

    [BsonElement("Clientes atendidos")]
    public int ClientesAtendidos { get; set; }

    [BsonElement("nombre del Reporte mensual")]
    public string Descripcion { get; set; }

    [BsonElement("Promedio de ventas diarias")]
    public double PromedioVentasDiarias { get; set; }

    [BsonElement("Mes")]
    public int Mes { get; set; }

    [BsonElement("año")]
    public int Año { get; set; }
}
