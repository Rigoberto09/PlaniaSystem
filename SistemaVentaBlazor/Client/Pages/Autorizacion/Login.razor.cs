using Microsoft.AspNetCore.Components;
using MudBlazor;
using SistemaPlania.Client.Servicios.Implementacion;
using SistemaPlania.Client.Utilidades;
//using SistemaPlania.Server.ConsultasDB;
using SistemaPlania.Server.ConsultasDB;

namespace SistemaPlania.Client.Pages.Autorizacion
{
    public partial class Login
    {
        #region variables locales
        private bool isValidUser;
        UsuarioLogin usuarioLogin = new UsuarioLogin();
        string myImageClass { get; set; } = "d-none";
        string myAlert { get; set; } = "d-none";
        bool disableButton { get; set; } = false;

        bool PasswordVisibility;
        InputType PasswordInput = InputType.Password;
        string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;

        #endregion

        void TogglePasswordVisibility()
        {
            if(PasswordVisibility)
            {
                PasswordVisibility = false;
                PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
                PasswordInput = InputType.Password;
            }
        else
            {
                PasswordVisibility = true;
                PasswordInputIcon = Icons.Material.Filled.Visibility;
                PasswordInput = InputType.Text;
            }
        }

        private void OnValidSubmit()
        {
            myImageClass = "d-block";
            disableButton = true;

            // Verificar usuario
            this.isValidUser = UsuarioDB.ObtenerUsuarioPorCorreo(usuarioLogin.Correo, usuarioLogin.Password);
            //this.isValidUser = true;

            if (this.isValidUser)
            {
                _navigationManager.NavigateTo("/page/dashboard");
            }
            else
            {
                myImageClass = "d-none";
                disableButton = false;
                myAlert = "d-block";
            }
        }
    }
}
