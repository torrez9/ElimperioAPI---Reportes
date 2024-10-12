namespace ElimperioAPI.Data
{
    public class ImperioDBsettings
    {
        public string CadenaConexion { get; set; } = null!;
        public string NombreBaseDatos { get; set; } = null!;
        public string ColeccionImperio { get; set; } = null!;
        public string ColeccionReportesMensuales { get; set; } = null!;

        // Método para validar que los campos esenciales no sean nulos o vacíos
        public void ValidarConfiguraciones()
        {
            if (string.IsNullOrEmpty(CadenaConexion))
                throw new ArgumentException("Cadena de conexión no puede ser nula o vacía.");
            if (string.IsNullOrEmpty(NombreBaseDatos))
                throw new ArgumentException("Nombre de la base de datos no puede ser nulo o vacío.");
            if (string.IsNullOrEmpty(ColeccionImperio))
                throw new ArgumentException("El nombre de la colección Imperio no puede ser nulo o vacío.");
            if (string.IsNullOrEmpty(ColeccionReportesMensuales))
                throw new ArgumentException("El nombre de la colección Reportes Mensuales no puede ser nulo o vacío.");
        }
    }
}
