using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ElImperioReportes.Models;
using ElimperioAPI.Data;
using MongoDB.Bson;

namespace ElimperioAPI.Services
{
    public class ReportMensualService
    {
        private readonly IMongoCollection<ReporteMensual> _reporteMensualCollection;

        // Constructor que inicializa la conexión a la base de datos usando IOptions para obtener los settings.
        public ReportMensualService(IOptions<ImperioDBsettings> configuracionBD)
        {
            // Crea la conexión a la base de datos usando los settings proporcionados
            var clienteMongo = new MongoClient(configuracionBD.Value.CadenaConexion);
            var BaseDatos = clienteMongo.GetDatabase(configuracionBD.Value.NombreBaseDatos);

            // Obtén la colección de reportes mensuales, usando la clave "ColeccionReportesMensuales"
            _reporteMensualCollection = BaseDatos.GetCollection<ReporteMensual>(configuracionBD.Value.ColeccionReportesMensuales);
        }

        // Método para obtener todos los reportes mensuales (sin filtros)
        public async Task<List<ReporteMensual>> ObtenerTodosAsync() =>
            await _reporteMensualCollection.Find(_ => true).ToListAsync();

        // Método para obtener un reporte mensual basado en su id
        public async Task<ReporteMensual> ObtenerAsync(string id) =>
            await _reporteMensualCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        // Método para obtener el reporte mensual basado en un mes y año
        public async Task<List<ReporteMensual>> ObtenerPorMesYAñoAsync(int mes, int año)
        {
            var filter = Builders<ReporteMensual>.Filter.Where(reporte => reporte.Mes == mes && reporte.Año == año);
            return await _reporteMensualCollection.Find(filter).ToListAsync();
        }

        // Método para agregar un nuevo reporte mensual
        public async Task CrearAsync(ReporteMensual nuevoReporte) =>
            await _reporteMensualCollection.InsertOneAsync(nuevoReporte);

        // Método para actualizar un reporte mensual basado en su id
        public async Task ActualizarAsync(string id, ReporteMensual reporteActualizado) =>
            await _reporteMensualCollection.ReplaceOneAsync(x => x.Id == id, reporteActualizado);
    }
}
