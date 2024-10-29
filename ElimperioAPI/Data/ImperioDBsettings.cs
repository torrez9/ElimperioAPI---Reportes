namespace ElimperioAPI.Data
{
    public class ImperioDBsettings
    {
        public string CadenaConexion { get; set; } = null!;
        public string NombreBaseDatos { get; set; } = null!;
        public string ColeccionImperio { get; set; } = null!;
        public string ColeccionInventario { get; set; } = null!;
        public string ColeccionVentaGeneral { get; set; } = null!;
        public string ColeccionVentaPorDia { get; set; } = null!;
        public string ColeccionProductoMasVendido { get; set; } = null!;
        public string ColeccionBebidaMasVendida { get; set; } = null!;
        public string ColeccionReportesMensuales { get; set; } = null!;
        public string ColeccionReportesSemanales { get; set; } = null!;
        public string ColeccionPlatoMasVendido { get; set; } = null!;



        // Método para validar que los campos esenciales no sean nulos o vacíos
        public void ValidarConfiguraciones()
        {
            if (string.IsNullOrEmpty(CadenaConexion))
                throw new ArgumentException("Cadena de conexión no puede ser nula o vacía.", nameof(CadenaConexion));
            if (string.IsNullOrEmpty(NombreBaseDatos))
                throw new ArgumentException("Nombre de la base de datos no puede ser nulo o vacío.", nameof(NombreBaseDatos));
            if (string.IsNullOrEmpty(ColeccionImperio))
                throw new ArgumentException("El nombre de la colección Imperio no puede ser nulo o vacío.", nameof(ColeccionImperio));
            if (string.IsNullOrEmpty(ColeccionInventario))
                throw new ArgumentException("El nombre de la colección Inventario no puede ser nulo o vacío.", nameof(ColeccionInventario));
            if (string.IsNullOrEmpty(ColeccionVentaGeneral))
                throw new ArgumentException("El nombre de la colección Venta General no puede ser nulo o vacío.", nameof(ColeccionVentaGeneral));
            if (string.IsNullOrEmpty(ColeccionVentaPorDia))
                throw new ArgumentException("El nombre de la colección Venta por Día no puede ser nulo o vacío.", nameof(ColeccionVentaPorDia));
            if (string.IsNullOrEmpty(ColeccionProductoMasVendido))
                throw new ArgumentException("El nombre de la colección Producto Más Vendido no puede ser nulo o vacío.", nameof(ColeccionProductoMasVendido));
            if (string.IsNullOrEmpty(ColeccionBebidaMasVendida))
                throw new ArgumentException("El nombre de la colección Bebida Más Vendida no puede ser nulo o vacío.", nameof(ColeccionBebidaMasVendida));
            if (string.IsNullOrEmpty(ColeccionReportesMensuales))
                throw new ArgumentException("El nombre de la colección Reportes Mensuales no puede ser nulo o vacío.", nameof(ColeccionReportesMensuales));
            if (string.IsNullOrEmpty(ColeccionReportesSemanales))
                throw new ArgumentException("El nombre de la colección Reportes Semanales no puede ser nulo o vacío.", nameof(ColeccionReportesSemanales));
        }
    }
}
