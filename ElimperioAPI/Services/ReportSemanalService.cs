using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ElImperioReportes.Models;
using ElimperioAPI.Data;

namespace ElimperioAPI.Services
{
    public class ReportSemanalService
    {
        private readonly IMongoCollection<ReporteSemanal> _reporteSemanalCollection;

        public ReportSemanalService(IOptions<ImperioDBsettings> configuracionBD)
        {
            var clienteMongo = new MongoClient(configuracionBD.Value.CadenaConexion);
            var BaseDatos = clienteMongo.GetDatabase(configuracionBD.Value.NombreBaseDatos);

            // Aquí usamos la nueva colección para los reportes semanales
            _reporteSemanalCollection = BaseDatos.GetCollection<ReporteSemanal>(configuracionBD.Value.ColeccionReportesSemanales);
        }

        public async Task<List<ReporteSemanal>> ObtenerAsync() =>
            await _reporteSemanalCollection.Find(_ => true).ToListAsync();

        public async Task<ReporteSemanal> ObtenerAsync(string id) =>
            await _reporteSemanalCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<List<ReporteSemanal>> ObtenerPorSemanaYAñoAsync(int semana, int año)
        {
            var filter = Builders<ReporteSemanal>.Filter.Where(reporte => reporte.Semana == semana && reporte.Año == año);
            return await _reporteSemanalCollection.Find(filter).ToListAsync();
        }

        public async Task CrearReporteSemanalAsync(ReporteSemanal nuevoReporte)
        {
            await _reporteSemanalCollection.InsertOneAsync(nuevoReporte);
        }

        public async Task ActualizarAsync(string id, ReporteSemanal reporteActualizado) =>
            await _reporteSemanalCollection.ReplaceOneAsync(x => x.Id == id, reporteActualizado);
    }
}
