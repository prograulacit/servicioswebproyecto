using BLL.Logica;
using BLL.Objeto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Application.Paginas.Compartido
{
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void button_submit_login_Click(object sender, EventArgs e)
        {
            if (estanTodosLosEspeciosVacios() &&
                usuarioEsUnico() &&
                contraseniaCoincide())
            {
                string nombre = textbox_nombre.Text;
                string apellido_paterno = textbox_ap_paterno.Text;
                string apellido_materno = textbox_ap_materno.Text;
                string correoElectronico = textbox_correo_electronico.Text;
                string nombreUsuario = textbox_nombre_de_usuario.Text;
                string contrasenia = textbox_contrasenia.Text;
                string confirmarContrasenia = textbox_confirmar_contrasenia.Text;

                Usuario usuario = new Usuario(Tareas.generar_nuevo_id_para_un_registro()
                    , nombre, apellido_paterno, apellido_materno
                    , correoElectronico, nombreUsuario, contrasenia);

                usuario.guardarNuevoUsuario(usuario);

                status_labels("", $"Usuario {nombreUsuario} registrado!");

                Memoria.sesionUsuarioDatos = usuario;

                Memoria.sesionDeUsuario = true;

                Response.Redirect("~/Paginas/Frontend/index.aspx");
            }
        }

        private void status_labels(string error, string success)
        {
            Label4_success.Text = success;
            Label_error.Text = error;
        }

        private bool contraseniaCoincide()
        {
            if (textbox_contrasenia.Text.Equals(
                textbox_confirmar_contrasenia.Text))
            {
                return true;
            }
            else
            {
                status_labels("La contraseña no coincide", "");
                return false;
            }
        }

        private bool usuarioEsUnico()
        {
            Usuario u = new Usuario();
            List<Usuario> lista_usuario = u.traerUsuarios();

            if (lista_usuario != null)
            {
                if (lista_usuario.Count > 0)
                {
                    for (int i = 0; i < lista_usuario.Count; i++)
                    {
                        if (textbox_nombre_de_usuario.Text.Equals(
                            lista_usuario[i].nombreUsuario))
                        {
                            status_labels("El nombre de usuario ya ha sido tomado", "");
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

        private bool estanTodosLosEspeciosVacios()
        {
            string nombre = textbox_nombre.Text;
            string apellido_paterno = textbox_ap_paterno.Text;
            string apellido_materno = textbox_ap_materno.Text;
            string correoElectronico = textbox_correo_electronico.Text;
            string nombreUsuario = textbox_nombre_de_usuario.Text;
            string contrasenia = textbox_contrasenia.Text;
            string confirmarContrasenia = textbox_confirmar_contrasenia.Text;

            if (!string.IsNullOrEmpty(nombre) &&
                !string.IsNullOrEmpty(apellido_paterno) &&
                !string.IsNullOrEmpty(apellido_materno) &&
                !string.IsNullOrEmpty(correoElectronico) &&
                !string.IsNullOrEmpty(nombreUsuario) &&
                !string.IsNullOrEmpty(contrasenia) &&
                !string.IsNullOrEmpty(confirmarContrasenia))
            {
                return true;
            }
            else
            {
                status_labels("Rellene todos los espacios", "");
                return false;
            }
        }
    }
}