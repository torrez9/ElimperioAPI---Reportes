using ElimperioAPI.Data;
using ElImperioReportes.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ElimperioAPI.Services.ReportServices
{
    public class BebidaMasVendidaService
    {
        private readonly IMongoCollection<BebidaMasVendida> _bebidaMasVendidaCollection;

        public BebidaMasVendidaService(IOptions<ImperioDBsettings> configuracionBD)
        {
            var clienteMongo = new MongoClient(configuracionBD.Value.CadenaConexion);
            var BaseDatos = clienteMongo.GetDatabase(configuracionBD.Value.NombreBaseDatos);
            _bebidaMasVendidaCollection = BaseDatos.GetCollection<BebidaMasVendida>(configuracionBD.Value.ColeccionBebidaMasVendida);
        }

        public async Task<List<BebidaMasVendida>> ObtenerAsync() =>
            await _bebidaMasVendidaCollection.Find(_ => true).ToListAsync();

        public async Task<BebidaMasVendida?> ObtenerAsync(string id) =>
            await _bebidaMasVendidaCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CrearAsync(BebidaMasVendida nuevaBebida) =>
            await _bebidaMasVendidaCollection.InsertOneAsync(nuevaBebida);

        public async Task ActualizarAsync(string id, BebidaMasVendida bebidaActualizada) =>
            await _bebidaMasVendidaCollection.ReplaceOneAsync(x => x.Id == id, bebidaActualizada);

        public async Task EliminarAsync(string id) =>
            await _bebidaMasVendidaCollection.DeleteOneAsync(x => x.Id == id);
    }

}
