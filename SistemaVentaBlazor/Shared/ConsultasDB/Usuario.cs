using Microsoft.Data.Sqlite;

namespace SistemaPlania.Server.ConsultasDB
{
    public class UsuarioDB
    {
        private static string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Planias.db");

        #region Consultas Usuario

        #region Insertar Nuevo Usuario
        public static void InsertarUsuario(string nombreApellidos, string correo, int idRol, string clave, int esActivo)
        {
            using (var connection = new SqliteConnection($"Data Source={dbPath}"))
            {
                connection.Open();

                string insertQuery = @"
                    INSERT INTO Usuario (nombreApellidos, correo, idRol, clave, esActivo)
                    VALUES (@nombreApellidos, @correo, @idRol, @clave, @esActivo);
                ";

                using (var command = new SqliteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@nombreApellidos", nombreApellidos);
                    command.Parameters.AddWithValue("@correo", correo);
                    command.Parameters.AddWithValue("@idRol", idRol);
                    command.Parameters.AddWithValue("@clave", clave);
                    command.Parameters.AddWithValue("@esActivo", esActivo);

                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Consultar Usuario por Correo
        public static bool ObtenerUsuarioPorCorreo(string correo, string contra)
        {
            using (var connection = new SqliteConnection($"Data Source={dbPath}"))
            {
                connection.Open();

                string selectQuery = @"
                        SELECT COUNT(1) FROM Usuario
                        WHERE correo = @correo AND clave = @clave;
                    ";

                using (var command = new SqliteCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@correo", correo);
                    command.Parameters.AddWithValue("@clave", contra);

                    // Ejecuta el comando y obtiene el conteo
                    var result = command.ExecuteScalar();
                    // Si el resultado es mayor que 0, el usuario existe
                    return Convert.ToInt32(result) > 0;
                }
            }
        }
        #endregion

        #endregion

    }
}
