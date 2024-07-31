using DocumentFormat.OpenXml.Spreadsheet;
using SistemaPlania.Server.ConsultasDB;
using System;
namespace SistemaPlania.Client.Pages.Autorizacion
{
    public partial class Login
    {
        #region variables locales
        private string? correo;
        private string? contra;

        private bool? respuesta;
        #endregion
        private void mostrarConexcionDataBase(string correo, string contra)
        {
            UsuarioDB.Mostrar();

            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contra))
            {
                // Mostrar mensaje de error al usuario o registrar evento
                return;
            }

            try
            {
                bool usuarioValido = UsuarioDB.ObtenerUsuarioPorCorreo(correo, contra);
                if (usuarioValido)
                {
                    // Proceder con el inicio de sesión
                    Console.WriteLine("Inicio de sesión exitoso.");
                }
                else
                {
                    // Mostrar mensaje de error al usuario
                    Console.WriteLine("Correo o contraseña incorrectos.");
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine($"Error al validar el usuario: {ex.Message}");
            }
        }

    }
}
