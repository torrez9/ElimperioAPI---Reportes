﻿using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using ElimperioAPI.Models;
using ElimperioAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace ElimperioAPI.Services.ReportServices
{
    public class ProductoService
    {
        private readonly IMongoCollection<Producto> _coleccionProducto;
        public ProductoService(IOptions<ImperioDBsettings> configuracionBD)
        {
            var clienteMongo = new MongoClient(configuracionBD.Value.CadenaConexion);
            var BaseDatos = clienteMongo.GetDatabase(configuracionBD.Value.NombreBaseDatos);
            _coleccionProducto = BaseDatos.GetCollection<Producto>(configuracionBD.Value.ColeccionImperio);
        }
        public async Task<List<Producto>> ObtenerAsync() => await _coleccionProducto.Find(_ => true).ToListAsync();
        public async Task<Producto> ObtenerAsync(string id) => await _coleccionProducto.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CrearAsync(Producto nuevoProducto)
        {
            //// Asignar un ObjectId a cada calificación si no tiene uno
            //foreach (var calificacion in nuevoEstudiante.Calificaciones)
            //{

            //    calificacion.Id = ObjectId.GenerateNewId().ToString();
            //}

            await _coleccionProducto.InsertOneAsync(nuevoProducto);
        }
        public async Task ActualizarAsync(string id, Producto productoActualizado) => await _coleccionProducto.ReplaceOneAsync(x => x.Id == id, productoActualizado);
    }
}
