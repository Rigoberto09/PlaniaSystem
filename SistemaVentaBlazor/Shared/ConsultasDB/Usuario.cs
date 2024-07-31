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
            try
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

                        var result = command.ExecuteScalar();
                        return Convert.ToInt32(result) > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine($"Error al obtener el usuario: {ex.Message}");
                return false;
            }
        }
        #endregion
        #region mostrar usuarios


        public static void Mostrar()
        {
            using (var connection = new SqliteConnection($"Data Source={dbPath}"))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM Usuario;";

                using (var command = new SqliteCommand(selectQuery, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idUsuario = reader.GetInt32(0); // Asumiendo que la columna idUsuario es la primera
                            string nombreApellidos = reader.GetString(1); // Asumiendo que la columna nombreApellidos es la segunda
                            string correo = reader.GetString(2); // Asumiendo que la columna correo es la tercera
                                                                 // Lee otros campos según sea necesario

                            // Muestra los datos o almacénalos según sea necesario
                            Console.WriteLine($"ID: {idUsuario}, Nombre: {nombreApellidos}, Correo: {correo}");
                        }
                    }
                }
            }
        }

        #endregion

        #endregion

    }
}
