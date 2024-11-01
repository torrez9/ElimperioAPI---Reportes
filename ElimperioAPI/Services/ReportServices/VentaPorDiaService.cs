using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ElImperioReportes.Models;
using ElimperioAPI.Data;

namespace ElimperioAPI.Services.ReportServices
{
    public class VentaPorDiaService
    {
        private readonly IMongoCollection<VentaPorDia> _ventaPorDiaCollection;

        public VentaPorDiaService(IOptions<ImperioDBsettings> configuracionBD)
        {
            var clienteMongo = new MongoClient(configuracionBD.Value.CadenaConexion);
            var BaseDatos = clienteMongo.GetDatabase(configuracionBD.Value.NombreBaseDatos);
            _ventaPorDiaCollection = BaseDatos.GetCollection<VentaPorDia>(configuracionBD.Value.ColeccionVentaPorDia);
        }

        public async Task<List<VentaPorDia>> ObtenerAsync() =>
            await _ventaPorDiaCollection.Find(_ => true).ToListAsync();

        public async Task<VentaPorDia> ObtenerAsync(string id) =>
            await _ventaPorDiaCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<List<VentaPorDia>> ObtenerPorFechaAsync(DateTime fecha)
        {
            var filter = Builders<VentaPorDia>.Filter.Eq(venta => venta.Fecha, fecha);
            return await _ventaPorDiaCollection.Find(filter).ToListAsync();
        }

        public async Task CrearAsync(VentaPorDia nuevaVentaPorDia) =>
            await _ventaPorDiaCollection.InsertOneAsync(nuevaVentaPorDia);

        public async Task ActualizarAsync(string id, VentaPorDia ventaActualizada) =>
            await _ventaPorDiaCollection.ReplaceOneAsync(x => x.Id == id, ventaActualizada);
    }
}
