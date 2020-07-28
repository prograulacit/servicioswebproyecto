using BLL.Logica;
using BLL.Objeto;
using System;

namespace Web_Application.Paginas.Frontend
{
    public partial class eliminarCuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Memoria.sesionDeUsuario)
            {
                Response.Redirect("~/Paginas/Compartido/index.aspx");
            }
        }

        protected void Button_eliminarCuenta_Click(object sender, EventArgs e)
        {
            if (espaciosLlenos() &&
                credencialesCorrectos())
            {
                // Se elimina el usuario.
                Memoria.sesionUsuarioDatos.borrarCuenta();

                // Vuelve al lobby.
                Response.Redirect("~/Paginas/Compartido/index.aspx");
            }
        }

        private bool credencialesCorrectos()
        {
            string nombre_usuario = TextBox_nombreUsuario.Text;
            string contrasenia = TextBox_contrasenia.Text;

            if (Memoria.sesionUsuarioDatos.nombreUsuario.Equals(nombre_usuario) &&
                Memoria.sesionUsuarioDatos.contrasenia.Equals(contrasenia))
            {
                return true;
            }
            else
            {
                label_status("Credenciales incorrectos.");
                return false;
            }
        }

        private bool espaciosLlenos()
        {
            if (!TextBox_nombreUsuario.Text.Equals("") &&
                !TextBox_contrasenia.Text.Equals(""))
            {
                return true;
            }
            else
            {
                label_status("Por favor, rellene todos los espacios");
                return false;
            }
        }

        private void label_status(string mensaje)
        {
            Label_status_error.Text = mensaje;
        }
    }
}