using Microsoft.Data.Sqlite;
using System;
using System.IO;

namespace SistemaPlania.Server.DataBase
{
    public class BaseDatos
    {

        private static string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Planias.db");

        public static void Inicializar()
        {
            try
            {
                using (var connection = new SqliteConnection($"Data Source={dbPath}"))
                {
                    connection.Open();

                    string tableRol = @"
                    CREATE TABLE IF NOT EXISTS Rol (
                        idRol INTEGER PRIMARY KEY AUTOINCREMENT,
                        descripcion TEXT,
                        esActivo INTEGER,
                        fechaRegistro TEXT DEFAULT CURRENT_TIMESTAMP
                    );";

                    string tableUsuario = @"
                    CREATE TABLE IF NOT EXISTS Usuario (
                        idUsuario INTEGER PRIMARY KEY AUTOINCREMENT,
                        nombreApellidos TEXT,
                        correo TEXT,
                        idRol INTEGER,
                        clave TEXT,
                        esActivo INTEGER,
                        FOREIGN KEY (idRol) REFERENCES Rol(idRol)
                    );";

                    string tableCategoria = @"
                    CREATE TABLE IF NOT EXISTS Categoria (
                        idCategoria INTEGER PRIMARY KEY AUTOINCREMENT,
                        descripcion TEXT,
                        esActivo INTEGER,
                        fechaRegistro TEXT DEFAULT CURRENT_TIMESTAMP
                    );";

                    string tableProducto = @"
                    CREATE TABLE IF NOT EXISTS Producto (
                        idProducto INTEGER PRIMARY KEY AUTOINCREMENT,
                        nombre TEXT,
                        idCategoria INTEGER,
                        stock INTEGER,
                        precio REAL,
                        esActivo INTEGER,
                        fechaRegistro TEXT DEFAULT CURRENT_TIMESTAMP,
                        FOREIGN KEY (idCategoria) REFERENCES Categoria(idCategoria)
                    );";

                    string tableNumeroDocumento = @"
                    CREATE TABLE IF NOT EXISTS NumeroDocumento (
                        idNumeroDocumento INTEGER PRIMARY KEY AUTOINCREMENT,
                        ultimo_Numero INTEGER NOT NULL,
                        fechaRegistro TEXT DEFAULT CURRENT_TIMESTAMP
                    );";

                    string tableVenta = @"
                    CREATE TABLE IF NOT EXISTS Venta (
                        idVenta INTEGER PRIMARY KEY AUTOINCREMENT,
                        numeroDocumento TEXT,
                        tipoPago TEXT,
                        fechaRegistro TEXT DEFAULT CURRENT_TIMESTAMP,
                        total REAL
                    );";

                    string tableDetalleVenta = @"
                    CREATE TABLE IF NOT EXISTS DetalleVenta (
                        idDetalleVenta INTEGER PRIMARY KEY AUTOINCREMENT,
                        idVenta INTEGER,
                        idProducto INTEGER,
                        cantidad INTEGER,
                        precio REAL,
                        total REAL,
                        FOREIGN KEY (idVenta) REFERENCES Venta(idVenta),
                        FOREIGN KEY (idProducto) REFERENCES Producto(idProducto)
                    );";

                    using (var command = new SqliteCommand(tableRol, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (var command = new SqliteCommand(tableUsuario, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (var command = new SqliteCommand(tableCategoria, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (var command = new SqliteCommand(tableProducto, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (var command = new SqliteCommand(tableNumeroDocumento, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (var command = new SqliteCommand(tableVenta, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (var command = new SqliteCommand(tableDetalleVenta, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al iniciar BaseDato " + ex);
            }

        }
    }
}
