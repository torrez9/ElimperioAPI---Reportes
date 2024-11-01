using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ElImperioReportes.Models;
using ElimperioAPI.Data;

namespace ElimperioAPI.Services.ReportServices
{
    public class VentaGeneralService
    {
        private readonly IMongoCollection<VentaGeneral> _ventaGeneralCollection;

        public VentaGeneralService(IOptions<ImperioDBsettings> configuracionBD)
        {
            var clienteMongo = new MongoClient(configuracionBD.Value.CadenaConexion);
            var BaseDatos = clienteMongo.GetDatabase(configuracionBD.Value.NombreBaseDatos);
            _ventaGeneralCollection = BaseDatos.GetCollection<VentaGeneral>(configuracionBD.Value.ColeccionVentaGeneral);
        }

        public async Task<List<VentaGeneral>> ObtenerAsync() =>
            await _ventaGeneralCollection.Find(_ => true).ToListAsync();

        public async Task<VentaGeneral> ObtenerAsync(string id) =>
            await _ventaGeneralCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<List<VentaGeneral>> ObtenerPorMesYAñoAsync(int mes, int año)
        {
            var filter = Builders<VentaGeneral>.Filter.Where(venta => venta.Mes == mes && venta.Año == año);
            return await _ventaGeneralCollection.Find(filter).ToListAsync();
        }

        //Crear Venta general
        public async Task CrearAsync(VentaGeneral nuevaVentaGeneral) =>
            await _ventaGeneralCollection.InsertOneAsync(nuevaVentaGeneral);

        //venta actualizada
        public async Task ActualizarAsync(string id, VentaGeneral ventaActualizada) =>
            await _ventaGeneralCollection.ReplaceOneAsync(x => x.Id == id, ventaActualizada);
    }
}
