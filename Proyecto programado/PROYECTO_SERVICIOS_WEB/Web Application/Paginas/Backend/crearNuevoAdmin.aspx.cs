using System;
using System.Collections.Generic;
using BLL.Logica;
using BLL.Objeto;

namespace Web_Application.Paginas.Backend
{
    public partial class crearNuevoAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool adminMaestro = Memoria.sesionAdminDatos.adminMaestro;
            bool adminSeguridad = Memoria.sesionAdminDatos.adminSeguridad;

            if (!adminMaestro && !adminSeguridad)
            {
                Response.Redirect("~/Paginas/Backend/Index.aspx");
            }
        }

        protected void Button_crearAdmin_Click(object sender, EventArgs e)
        {
            // Se comprueba que todo los input esten rellenos
            if (estanTodosLosEspaciosLlenos() &&
                hayAlMenosUnRolSeleccionado() &&
                esUnNombreDeUsuarioUnico())
            {
                // Se capturan los input.
                string nombreUsuario = TextBox_nombreUsuario.Text;
                string contrasenia = TextBox_contrasenia.Text;
                string correoElectronico = TextBox_correoElectronico.Text;
                string preguntaSeguridad = TextBox_preguntaSeguridad.Text;
                string respuestaSeguridad = TextBox_respuestaDeSeguridad.Text;
                bool adminMaestro = CheckBox_adminMaestro.Checked;
                bool adminSeguridad = CheckBox_adminSeguridad.Checked;
                bool adminMantenimiento = CheckBox_mantenimiento.Checked;
                bool adminConsultas = CheckBox_consultas.Checked;

                // Se crea un nuevo objeto admin para guardar en la base de datos.
                Admin admin = new Admin("id_vacio"
                    , nombreUsuario
                    , contrasenia
                    , correoElectronico
                    , preguntaSeguridad
                    , respuestaSeguridad
                    , adminMaestro
                    , adminSeguridad
                    , adminMantenimiento
                    , adminConsultas);

                // Se envia el objeto admin a un metodo llamado crearNuevoAdmin_UI
                // el cual se encarga de darle un id al admin segun corresponda
                // en relación a los consecutivos así como actualizar el registro
                // de consecutivos.
                admin.crearNuevoAdmin_UI(admin);

                // Guardamos una bitacora.
                Bitacora b = new Bitacora();
                b.guardarBitacora_interfazDeUsuario("Movimiento a otro admin"
                    , "Un nuevo administrador a sido creado."
                    , $"El administrador {Memoria.sesionAdminDatos.nombreUsuario} a " +
                    $"creado un nuevo administrador con el nombre de usuario " +
                    $"{nombreUsuario} el cual tiene los permisos de: AdminMaestro: {adminMaestro}, " +
                    $"AdminSeguridad: {adminSeguridad}, AdminMantenimiento: {adminMantenimiento}, " +
                    $"AdminConsultas: {adminConsultas}.");

                // Se da feedback al administrador en el user interface.
                adminCreado_cambiosUI();
            }
        }

        private void adminCreado_cambiosUI()
        {
            TextBox_nombreUsuario.Text = "";
            TextBox_contrasenia.Text = "";
            TextBox_correoElectronico.Text = "";
            TextBox_preguntaSeguridad.Text = "";
            TextBox_respuestaDeSeguridad.Text = "";
            CheckBox_adminMaestro.Checked = false;
            CheckBox_adminSeguridad.Checked = false;
            CheckBox_mantenimiento.Checked = false;
            CheckBox_consultas.Checked = false;

            Label_status_success.Text = "Admin creado con exito";
            labelStatusDanger_cambiarTexto("");
        }

        protected void Button_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Backend/Index.aspx");
        }

        #region verificaciones
        private bool estanTodosLosEspaciosLlenos()
        {
            if (!String.IsNullOrEmpty(TextBox_nombreUsuario.Text) &&
            !String.IsNullOrEmpty(TextBox_contrasenia.Text) &&
            !String.IsNullOrEmpty(TextBox_correoElectronico.Text) &&
            !String.IsNullOrEmpty(TextBox_preguntaSeguridad.Text) &&
            !String.IsNullOrEmpty(TextBox_respuestaDeSeguridad.Text))
            {
                return true;
            }
            else

            {
                Label_status_success.Text = "";
                labelStatusDanger_cambiarTexto("Por favor, rellene todos los espacios.");
                return false;
            }
        }

        private bool hayAlMenosUnRolSeleccionado()
        {
            if (CheckBox_adminMaestro.Checked ||
            CheckBox_adminSeguridad.Checked ||
            CheckBox_mantenimiento.Checked ||
            CheckBox_consultas.Checked)
            {
                return true;
            }
            else
            {
                Label_status_success.Text = "";
                labelStatusDanger_cambiarTexto("Por favor, asigne por lo menos 1 rol.");
                return false;
            }
        }

        private bool esUnNombreDeUsuarioUnico()
        {
            Admin admin = new Admin();
            List<Admin> lista_admins = admin.traerAdmins();
            for (int i = 0; i < lista_admins.Count; i++)
            {
                if (TextBox_nombreUsuario.Text.ToLower() == 
                    lista_admins[i].nombreUsuario.ToLower())
                {
                    labelStatusDanger_cambiarTexto("Ese nombre de usuario ya está tomado.");
                    Label_status_success.Text = "";
                    return false;
                }
            }
            return true;
        }
        #endregion

        private void labelStatusDanger_cambiarTexto(string mensaje)
        {
            Label_status_error.Text = mensaje;
        }
    }
}