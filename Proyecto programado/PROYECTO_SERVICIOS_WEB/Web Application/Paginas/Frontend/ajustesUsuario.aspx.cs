using BLL.Logica;
using BLL.Objeto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Application.Paginas.Frontend
{
    public partial class ajustesUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Memoria.sesionDeUsuario)
            {
                Response.Redirect("~/Paginas/Compartido/index.aspx");
            }
        }

        protected void Button_actualizarDatos_Click(object sender, EventArgs e)
        {
            if (espaciosDeParametrosLlenos() &&
                nombreDeUsuarioUnico())
            {

            }
        }

        private bool nombreDeUsuarioUnico()
        {
            Usuario u = new Usuario();
            List<Usuario> lista_usuario = u.traerUsuarios();

            if (lista_usuario != null)
            {
                if (lista_usuario.Count > 0)
                {
                    for (int i = 0; i < lista_usuario.Count; i++)
                    {
                        if (TextBox_nombreUsuario.Text.Equals(
                            lista_usuario[i].nombreUsuario))
                        {
                            label_status_parametros("Nombre de usuario no disponible", false);
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        #region Label Status
        /// <summary>
        /// Cambia el texto y color de label_status_parametros
        /// </summary>
        /// <param name="mensaje">Mensaje a mostrar.</param>
        /// <param name="status">true para mensaje success. false 
        /// para mensaje failure.</param>
        private void label_status_parametros(string mensaje, bool status)
        {
            if (status)
            {
                Label_status_success_parametros.Text = mensaje;
                Label_status_failed_parametros.Text = "";

                Label_status_success_parametros.Visible = true;
                Label_status_failed_parametros.Visible = false;
            }
            else
            {
                Label_status_success_parametros.Text = "";
                Label_status_failed_parametros.Text = mensaje;

                Label_status_success_parametros.Visible = false;
                Label_status_failed_parametros.Visible = true;
            }
        }

        /// <summary>
        /// Cambia el texto y color de label_status_parametros
        /// </summary>
        /// <param name="mensaje">Mensaje a mostrar.</param>
        /// <param name="status">true para mensaje success. false 
        /// para mensaje failure.</param>
        private void label_status_contrasenia(string mensaje, bool status)
        {
            if (status)
            {
                Label1_status_success_contrasenia.Text = mensaje;
                Label1_status_failed_contrasenia.Text = "";

                Label1_status_success_contrasenia.Visible = true;
                Label1_status_failed_contrasenia.Visible = false;
            }
            else
            {
                Label1_status_success_contrasenia.Text = "";
                Label1_status_failed_contrasenia.Text = mensaje;

                Label1_status_success_contrasenia.Visible = false;
                Label1_status_failed_contrasenia.Visible = true;
            }
        }
        #endregion

        private bool espaciosDeParametrosLlenos()
        {
            throw new NotImplementedException();
        }

        protected void Button_actualizarContrasenia_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton_borrarCuenta_Click(object sender, EventArgs e)
        {

        }
    }
}