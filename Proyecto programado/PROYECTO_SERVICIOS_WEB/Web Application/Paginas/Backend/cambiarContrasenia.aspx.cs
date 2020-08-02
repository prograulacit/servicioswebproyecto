using BLL.Logica;
using BLL.Objeto;
using System;

namespace Web_Application.Paginas.Backend
{
    public partial class cambiarContrasenia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Memoria.sesionDeAdmin)
            {
                Response.Redirect("~/Paginas/Backend/Index.aspx");
            }
        }

        protected void Button_confirmar_Click(object sender, EventArgs e)
        {
            if (sinEspaciosVacios() &&
                contraseniaNuevaYConfirmarCoincide() &&
                contraseniaActualCoincide())
            {
                realizarCambioContrasenia();
            }
        }

        private void realizarCambioContrasenia()
        {
            // Cambiamos la contraseña del administrador en la memoria.
            string contraseniaNueva = TextBox_contraseniaNueva.Text;
            Memoria.sesionAdminDatos.contrasenia = contraseniaNueva;

            // Actualizamos la contraseña del administrador en la base
            // de datos.
            Memoria.sesionAdminDatos
                .actualizarAdmin(Memoria.sesionAdminDatos);

            // Guardamos una bitacora de cambio de contraseña.
            //Bitacora b = new Bitacora();
            //b.guardarBitacora_interfazDeUsuario("Cambio de contraseña"
            //    , "Un administrador cambio su contraseña."
            //    , $"El administrador {Memoria.sesionAdminDatos.nombreUsuario} a cambiado su " +
            //    $"contraseña de ingreso al sistema.");

            label_status_change("", "Contraseña actualizada con exito");
            limpiarCajasDeTexto();
        }

        private void limpiarCajasDeTexto()
        {
            TextBox_contraseniaActual.Text = "";
            TextBox_contraseniaNueva.Text = "";
            TextBox_confirmarContrasenia.Text = "";
        }

        #region Validaciones
        private bool contraseniaActualCoincide()
        {
            if (Memoria.sesionAdminDatos.contrasenia
                .Equals(TextBox_contraseniaActual.Text))
            {
                return true;
            }
            else
            {
                label_status_change("La contraseña actual no es correcta.", "");
                return false;
            }
        }

        private bool contraseniaNuevaYConfirmarCoincide()
        {
            if (TextBox_contraseniaNueva.Text
                .Equals(TextBox_confirmarContrasenia.Text))
            {
                return true;
            }
            else
            {
                label_status_change("Las contraseñas no coinciden.", "");
                return false;
            }
        }

        private bool sinEspaciosVacios()
        {
            if (!string.IsNullOrEmpty(TextBox_contraseniaActual.Text) &&
                !string.IsNullOrEmpty(TextBox_contraseniaNueva.Text) &&
                !string.IsNullOrEmpty(TextBox_confirmarContrasenia.Text))
            {
                return true;
            }
            else
            {
                label_status_change("Por favor, rellene todos los espacios.", "");
                return false;
            }
        }
        #endregion

        private void label_status_change(string error, string success)
        {
            Label_status_error.Text = error;
            Label_status_success.Text = success;
        }

        protected void Button_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Backend/index.aspx");
        }
    }
}