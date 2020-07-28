using BLL.Logica;
using BLL.Objeto;
using System;
using System.Collections.Generic;

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

            Label_titulo.Text = "Ajustes del usuario " +
                Memoria.sesionUsuarioDatos.nombreUsuario;

            if (!Page.IsPostBack)
            {
                rellenarEspaciosDeParametos();
            }
        }

        #region Botones
        // Boton para actualizar parametros del usuario.
        protected void Button_actualizarDatos_Click(object sender, EventArgs e)
        {
            if (espaciosLlenos_parametros() &&
                nombreDeUsuarioUnico())
            {
                Usuario usuario_temporal = generarUsuarioTemporal();
                actualizarParametrosDelUsuario_memoria(usuario_temporal);
                actualizarParametrosDelUsuario_baseDeDatos(usuario_temporal);
                rellenarEspaciosDeParametos();
                label_status_global("Los parametros han sido actualizados", true,
                    "",true);
            }
        }

        // Boton para actualizar la contraseña.
        protected void Button_actualizarContrasenia_Click(object sender, EventArgs e)
        {
            if (espaciosLlenos_contrasenia() &&
                contraseniaCorrecta() &&
                contraseniaCoincide())
            {
                realizarCambioContrasenia();
                vaciarTextBox_contrasenia();
                label_status_global("",true
                    ,"Contraseña actualizada con exito",true);
            }
        }

        // Boton link que envia al usuario al formulario de eliminacion de cuenta.
        protected void LinkButton_borrarCuenta_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Frontend/eliminarCuenta.aspx");
        }
        #endregion

        #region Procesos logicos
        private void realizarCambioContrasenia()
        {
            string contraseniaNueva = TextBox_contraseniaNueva.Text;

            // Guardamos la contraseña nueva en la memoria.
            Memoria.sesionUsuarioDatos.contrasenia = contraseniaNueva;

            // Guardamos la información de la nueva contraseña
            // en la base de datos.
            Memoria.sesionUsuarioDatos
                .actualizarUsuario(Memoria.sesionUsuarioDatos);
        }

        private void actualizarParametrosDelUsuario_memoria(Usuario usuario_temporal)
        {
            // Actualizamos los datos del usuario logeado en la memoria.
            Memoria.sesionUsuarioDatos.nombre = usuario_temporal.nombre;
            Memoria.sesionUsuarioDatos.primerApellido = usuario_temporal.primerApellido;
            Memoria.sesionUsuarioDatos.segundoApellido = usuario_temporal.segundoApellido;
            Memoria.sesionUsuarioDatos.correoElectronico = usuario_temporal.correoElectronico;
            Memoria.sesionUsuarioDatos.nombreUsuario = usuario_temporal.nombreUsuario;
        }

        private void actualizarParametrosDelUsuario_baseDeDatos(Usuario usuario_temporal)
        {
            // Actualizamos el usuario en la base de datos.
            usuario_temporal.actualizarUsuario(usuario_temporal);
        }

        private Usuario generarUsuarioTemporal()
        {
            // Generamos un usuario temporal con los datos dados por el usuario.
            string nombre = TextBox_nombre.Text;
            string primer_apellido = TextBox_primer_apellido.Text;
            string segundo_apellido = TextBox_segundo_apellido.Text;
            string correo_electronico = TextBox_correo_electronico.Text;
            string nombreUsuario = TextBox_nombreUsuario.Text;

            return new Usuario(
                Memoria.sesionUsuarioDatos.id
                , nombre
                , primer_apellido
                , segundo_apellido
                , correo_electronico
                , nombreUsuario
                , Memoria.sesionUsuarioDatos.contrasenia);
        }

        // Por defecto se cargaran los parametros actuales del usuario en las cajas de
        // texto correspondientes.
        private void rellenarEspaciosDeParametos()
        {
            TextBox_nombre.Text = Memoria.sesionUsuarioDatos.nombre;
            TextBox_primer_apellido.Text = Memoria.sesionUsuarioDatos.primerApellido;
            TextBox_segundo_apellido.Text = Memoria.sesionUsuarioDatos.segundoApellido;
            TextBox_correo_electronico.Text = Memoria.sesionUsuarioDatos.correoElectronico;
            TextBox_nombreUsuario.Text = Memoria.sesionUsuarioDatos.nombreUsuario;
        }
        #endregion

        #region Validaciones
        private bool contraseniaCoincide()
        {
            if (TextBox_contraseniaNueva.Text.Equals(
                TextBox_contraseniaConfirmar.Text))
            {
                return true;
            }
            else
            {
                label_status_global("", true
                    , "La contraseña nueva y la de confirmacion no coinciden."
                    , false);
                return false;
            }
        }

        private bool contraseniaCorrecta()
        {
            if (TextBox_contraseniaActual.Text.Equals(
                Memoria.sesionUsuarioDatos.contrasenia))
            {
                return true;
            }
            else
            {
                label_status_global("",true,"La contraseña es incorrecta", false);
                return false;
            }
        }

        private bool espaciosLlenos_contrasenia()
        {
            if (!TextBox_contraseniaActual.Text.Equals("") &&
                !TextBox_contraseniaNueva.Text.Equals("") &&
                !TextBox_contraseniaConfirmar.Text.Equals(""))
            {
                return true;
            }
            else
            {
                label_status_global("",true,"Por favor, rellene todos los espacios", false);
                return false;
            }
        }

        /// <summary>
        /// Revisa si el nombre de usuario proporcionado es unico. 
        /// </summary>
        /// <returns>true si es unico. false si ya ha sido tomado.</returns>
        private bool nombreDeUsuarioUnico()
        {
            // Si el nombre de usuario es el mismo, no realizamos la validacion.
            if (TextBox_nombreUsuario.Text.Equals(
                Memoria.sesionUsuarioDatos.nombreUsuario))
            {
                return true;
            }

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
                            label_status_global("Nombre de usuario no disponible", false
                                , "", true);
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private bool espaciosLlenos_parametros()
        {
            if (!TextBox_nombre.Text.Equals("") &&
                !TextBox_primer_apellido.Text.Equals("") &&
                !TextBox_segundo_apellido.Text.Equals("") &&
                !TextBox_correo_electronico.Text.Equals("") &&
                !TextBox_nombreUsuario.Text.Equals(""))
            {
                return true;
            }
            else
            {
                label_status_global("Por favor, rellene todos los espacios.", false
                    , "", true);
                return false;
            }
        }

        #endregion

        #region Vaciar Textbox
        private void vaciarTextBox_parametros()
        {
            TextBox_nombre.Text = "";
            TextBox_primer_apellido.Text = "";
            TextBox_segundo_apellido.Text = "";
            TextBox_correo_electronico.Text = "";
            TextBox_nombreUsuario.Text = "";
        }

        private void vaciarTextBox_contrasenia()
        {
            TextBox_contraseniaActual.Text = "";
            TextBox_contraseniaNueva.Text = "";
            TextBox_contraseniaConfirmar.Text = "";
        }
        #endregion

        #region Label Status

        /// <summary>
        /// Cambia los label status de ambos tipos de error.
        /// </summary>
        /// <param name="mensaje_parametros"></param>
        /// <param name="status_parametros"></param>
        /// <param name="mensaje_contrasenia"></param>
        /// <param name="status_contrasenia"></param>
        private void label_status_global(string mensaje_parametros
            , bool status_parametros
            , string mensaje_contrasenia
            , bool status_contrasenia)
        {
            label_status_parametros(mensaje_parametros, status_parametros);
            label_status_contrasenia(mensaje_contrasenia, status_contrasenia);
        }

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
    }
}