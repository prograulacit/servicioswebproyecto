using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Objeto;
using BLL.Logica;

namespace Web_Application.Paginas.Backend
{
    public partial class login_preguntaSeguridad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Memoria.sesionDeAdmin)
            {
                if (String.IsNullOrEmpty(Memoria.sesionAdminDatos.id))
                {
                    Response.Redirect("~/Paginas/Compartido/index.aspx");
                }
                else
                {
                    Label_pistaPreguntaSeguridad.Text =
                        Memoria.sesionAdminDatos.preguntaSeguridad;
                }
            }
            else
            {
                Response.Redirect("~/Paginas/Backend/index.aspx");
            }
        }

        protected void Button_aceptar_Click(object sender, EventArgs e)
        {
            string respuestaDeSeguridad = TextBox_respuestaSeguridad.Text;

            if (respuestaDeSeguridad == Memoria.sesionAdminDatos.respuestaSeguridad)
            {
                // La respuesta es correcta.
                Memoria.sesionDeAdmin = true;
                Response.Redirect("~/Paginas/Backend/index.aspx");
            }
            else
            {
                // La respuesta es incorrecta.
                labelStatusDanger_cambiarTexto("La respuesta es incorrecta.");
            }
        }

        protected void Button_cancelar_Click(object sender, EventArgs e)
        {
            // Se cancela el logeo. Se borran los datos de adminstrador
            // de la memoria.
            Memoria.sesionAdminDatos = new Admin();

            // Se envia al usuario al lobby.
            Response.Redirect("~/Paginas/Compartido/index.aspx");
        }

        private void labelStatusDanger_cambiarTexto(string mensaje)
        {
            Label_status_error.Text = mensaje;
        }
    }
}