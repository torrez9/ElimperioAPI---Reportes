using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ElImperioReportes.Models;
using ElimperioAPI.Data;

namespace ElimperioAPI.Services
{
    public class InventarioService
    {
        private readonly IMongoCollection<ReporteInventario> _inventarioCollection;

        public InventarioService(IOptions<ImperioDBsettings> configuracionBD)
        {
            var clienteMongo = new MongoClient(configuracionBD.Value.CadenaConexion);
            var BaseDatos = clienteMongo.GetDatabase(configuracionBD.Value.NombreBaseDatos);

            _inventarioCollection = BaseDatos.GetCollection<ReporteInventario>(configuracionBD.Value.ColeccionInventario);
        }

        public async Task<List<ReporteInventario>> ObtenerAsync() =>
            await _inventarioCollection.Find(_ => true).ToListAsync();

        public async Task<ReporteInventario> ObtenerAsync(string id) =>
            await _inventarioCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CrearAsync(ReporteInventario nuevoReporte) =>
            await _inventarioCollection.InsertOneAsync(nuevoReporte);

        public async Task ActualizarAsync(string id, ReporteInventario reporteActualizado) =>
            await _inventarioCollection.ReplaceOneAsync(x => x.Id == id, reporteActualizado);
    }
}
