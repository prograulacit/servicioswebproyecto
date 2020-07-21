using System;
using System.Collections.Generic;
using BLL.Objeto;
using BLL.Logica;

namespace Web_Application.Paginas.Compartido
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Logica del botón de login.
        protected void button_submit_login_Click(object sender, EventArgs e)
        {
            // Comprobamos que los espacios esten llenos.
            if (estanLlenosLosEspacios())
            {
                comprobarCredencialesAdmin();
                //comprobarCredencialesUsuario(lista_admins);
            }
        }

        // Metodo que comprueba las credenciales.
        private void comprobarCredencialesAdmin()
        {
            // Traemos todos los registros de admin de la base de datos
            Admin admin = new Admin();
            List<Admin> lista_admins = admin.traerAdmins();

            // Capturamos los input del usuario.
            string nombreDeUsuario_input = textbox_nombre_usuario.Text;
            string contrasenia_input = textbox_contrasenia.Text;

            for (int i = 0; i < lista_admins.Count; i++)
            {
                // Comprobamos si la contraseña y nombre de usuario coinciden.
                if (lista_admins[i].contrasenia == contrasenia_input &&
                    lista_admins[i].nombreUsuario == nombreDeUsuario_input)
                {
                    // Si entramos aquí, se han encontrado datos que coinciden.
                    comprobacionExitosaAdmin(lista_admins[i]);
                    break;
                }
            }
            labelStatusDanger_cambiarTexto("El usuario ingresado no " +
                "existe o las crendeciales son incorrectas.");
        }

        private void comprobacionExitosaAdmin(Admin admin)
        {
            // Se guardan los datos completos de éste admistrador en la memoria.
            Memoria.sesionAdminDatos = admin;

            // El probable administrador es enviado al formulario de pregunta de
            // seguridad
            Response.Redirect("~/Paginas/Backend/login_preguntaSeguridad.aspx");
        }

        // Metodo que comprueba si todos los espacios están llenos.
        private bool estanLlenosLosEspacios()
        {
            if (!String.IsNullOrEmpty(textbox_nombre_usuario.Text) ||
                !String.IsNullOrEmpty(textbox_contrasenia.Text))
            {
                return true;
            }
            else
            {
                labelStatusDanger_cambiarTexto("Por favor, rellene todos los espacios.");
                return false;
            }
        }

        // Metodo que cambia el texto del error en pantalla que se muestra cuando es requedido.
        private void labelStatusDanger_cambiarTexto(string mensaje)
        {
            Label_status_error.Text = mensaje;
        }
    }
}