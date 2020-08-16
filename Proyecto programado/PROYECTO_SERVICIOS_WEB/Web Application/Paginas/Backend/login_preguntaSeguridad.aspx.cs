using System;
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

            if (!IsPostBack)
            {
                Label_status_error.Visible = false;
            }
        }

        protected void Button_aceptar_Click(object sender, EventArgs e)
        {
            string respuestaDeSeguridad = TextBox_respuestaSeguridad.Text;

            if (respuestaDeSeguridad == Memoria.sesionAdminDatos.respuestaSeguridad)
            {
                // La respuesta es correcta.
                Memoria.sesionDeAdmin = true;

                // Guardamos una bitacora de inicio de sesion.
                //Bitacora b = new Bitacora();
                //b.guardarBitacora_interfazDeUsuario("Inicio de sesion"
                //    , "Admin a iniciado sesion"
                //    , $"El administrador {Memoria.sesionAdminDatos.nombreUsuario} a ingresado " +
                //    $"en el sistema.");

                Response.Redirect("~/Paginas/Backend/index.aspx");
            }
            else
            {
                // La respuesta es incorrecta.
                Label_status_error.Visible = true;
                labelStatusDanger_cambiarTexto("La respuesta de seguridad es incorrecta.");
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