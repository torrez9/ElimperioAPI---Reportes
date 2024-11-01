using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ElImperioReportes.Models;
using ElimperioAPI.Data;

namespace ElimperioAPI.Services.ReportServices
{
    public class PlatoMasVendidoService
    {
        private readonly IMongoCollection<PlatoMasVendido> _platoMasVendidoCollection;

        public PlatoMasVendidoService(IOptions<ImperioDBsettings> configuracionBD)
        {
            var clienteMongo = new MongoClient(configuracionBD.Value.CadenaConexion);
            var baseDatos = clienteMongo.GetDatabase(configuracionBD.Value.NombreBaseDatos);
            _platoMasVendidoCollection = baseDatos.GetCollection<PlatoMasVendido>(configuracionBD.Value.ColeccionPlatoMasVendido);
        }

        // Obtener todos los platos más vendidos
        public async Task<List<PlatoMasVendido>> ObtenerAsync() =>
            await _platoMasVendidoCollection.Find(_ => true).ToListAsync();

        // Obtener un plato más vendido por ID
        public async Task<PlatoMasVendido?> ObtenerAsync(string id) =>
            await _platoMasVendidoCollection.Find(p => p.Id == id).FirstOrDefaultAsync();

        // Crear un nuevo plato más vendido
        public async Task CrearAsync(PlatoMasVendido nuevoPlato) =>
            await _platoMasVendidoCollection.InsertOneAsync(nuevoPlato);

        // Actualizar un plato más vendido
        public async Task ActualizarAsync(string id, PlatoMasVendido platoActualizado) =>
            await _platoMasVendidoCollection.ReplaceOneAsync(p => p.Id == id, platoActualizado);

        // Eliminar un plato más vendido
        public async Task EliminarAsync(string id) =>
            await _platoMasVendidoCollection.DeleteOneAsync(p => p.Id == id);
    }
}
