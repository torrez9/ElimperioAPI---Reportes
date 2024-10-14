using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ElImperioReportes.Models;
using ElimperioAPI.Data;

namespace ElimperioAPI.Services
{
    public class ProductoMasVendidoService
    {
        private readonly IMongoCollection<ProductoMasVendido> _productoMasVendidoCollection;

        public ProductoMasVendidoService(IOptions<ImperioDBsettings> configuracionBD)
        {
            var clienteMongo = new MongoClient(configuracionBD.Value.CadenaConexion);
            var BaseDatos = clienteMongo.GetDatabase(configuracionBD.Value.NombreBaseDatos);
            _productoMasVendidoCollection = BaseDatos.GetCollection<ProductoMasVendido>(configuracionBD.Value.ColeccionProductoMasVendido);
        }

        public async Task<List<ProductoMasVendido>> ObtenerAsync() =>
            await _productoMasVendidoCollection.Find(_ => true).ToListAsync();

        public async Task<ProductoMasVendido> ObtenerAsync(string id) =>
            await _productoMasVendidoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<List<ProductoMasVendido>> ObtenerPorMesYAñoAsync(int mes, int año)
        {
            var filter = Builders<ProductoMasVendido>.Filter.Where(producto => producto.Mes == mes && producto.Año == año);
            return await _productoMasVendidoCollection.Find(filter).ToListAsync();
        }

        public async Task CrearAsync(ProductoMasVendido nuevoProducto) =>
            await _productoMasVendidoCollection.InsertOneAsync(nuevoProducto);

        public async Task ActualizarAsync(string id, ProductoMasVendido productoActualizado) =>
            await _productoMasVendidoCollection.ReplaceOneAsync(x => x.Id == id, productoActualizado);
    }
}
