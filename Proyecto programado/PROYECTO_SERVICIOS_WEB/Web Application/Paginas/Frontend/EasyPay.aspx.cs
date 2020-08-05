using BLL.Logica;
using BLL.Objeto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Web_Application.Paginas.Frontend
{
    public partial class EasyPay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Memoria.sesionDeUsuario)
            {
                Response.Redirect("~/Paginas/Compartido/index.aspx");
            }
            // Los dropdowns se rellenan solo la primera vez que la pagina
            // ha sido cargada.
            if (!Page.IsPostBack)
            {
                label_status("", false, "", false);
            }
        }

        protected void Button_crearCuentaEasyPay_Click(object sender, EventArgs e)
        {
            if (espaciosRellenados() &&
                tarjetaSeleccionada() &&
                contraseniasCoinciden())
            {
                guardarCuentaEasyPay();
            }
        }

        #region label_status
        /// <summary>
        /// Cambia los estados de label_status_error y label_status_success
        /// </summary>
        /// <param name="mensaje_error">Mensaje de label_status_error</param>
        /// <param name="status_error">true hara lo hara visible, false invisible</param>
        /// <param name="mensaje_success">Mensaje de label_status_success</param>
        /// <param name="status_success">True hara lo hara visible, false invisible</param>
        private void label_status(
            string mensaje_error
            , bool status_error
            , string mensaje_success
            , bool status_success)
        {
            label_status_error(mensaje_error, status_error);
            label_status_success(mensaje_success, status_success);
        }

        private void label_status_error(string mensaje_error
            , bool status_error)
        {
            Label_status_error.Text = mensaje_error;
            Label_status_error.Visible = status_error;
        }

        private void label_status_success(string mensaje_success
            , bool status_success)
        {
            Label_status_success.Text = mensaje_success;
            Label_status_success.Visible = status_success;
        }
        #endregion

        #region Procesos logicos
        private void guardarCuentaEasyPay()
        {
            // Creamos el objeto EasyPay a guardar.
            BLL.Objeto.EasyPay easyPay_paraGuardar =
                contruirObjetoEasyPay();

            // Guardamos la cuenta EasyPay.
            easyPay_paraGuardar.guardar_easyPay(easyPay_paraGuardar);
            label_status("", false, "Cuenta EasyPay creada con exito.", true);
        }

        private BLL.Objeto.EasyPay contruirObjetoEasyPay()
        {
            BLL.Objeto.EasyPay EasyPay_temporal = new BLL.Objeto.EasyPay();

            // Capturamos los datos.
            string id = Tareas.generar_nuevo_id_para_un_registro();
            string id_usuario = Memoria.sesionUsuarioDatos.id;
            string id_tarjeta = Textbox_idTarjeta.Text;
            string codigoSeguridad = EasyPay_temporal.generarCodigoDeSeguridad();
            string contrasenia = TextBox_contraseniaNueva.Text;
            string monto = "NA";

            // Creamos el EasyPay a guardar.
            BLL.Objeto.EasyPay EasyPay_return = new BLL.Objeto.EasyPay(
                id
                , id_usuario
                , id_tarjeta
                , codigoSeguridad
                , contrasenia
                , monto);

            // Una vez establecido su tarjeta asociada podemos obtener el monto
            // reflejo de dicha tarjeta.
            monto = EasyPay_return.obtenerMontoActual();
            EasyPay_return.monto = monto;

            return EasyPay_return;
        }
        #endregion

        #region Validaciones
        private bool contraseniasCoinciden()
        {
            string contraseniaNueva = TextBox_contraseniaNueva.Text;
            string contraseniaConfirmar = TextBox_contraseniaConfirmar.Text;

            if (contraseniaNueva == contraseniaConfirmar)
            {
                return true;
            }
            label_status("La contraseña no coincide.", true, "", false);
            return false;
        }

        private bool tarjetaSeleccionada()
        {
            string id_tarjeta = Textbox_idTarjeta.Text;

            Tarjeta t = new Tarjeta();
            List<Tarjeta> lista_tarjetas =
                t.traerTarjetas_UsuarioId(Memoria.sesionUsuarioDatos.id);

            // Valida si la tarjeta existe en la base de datos.
            foreach (Tarjeta temTarjeta in lista_tarjetas)
            {
                if (temTarjeta.id == id_tarjeta)
                {
                    return true;
                }
            }
            // La tarjeta no existe o no se ha seleccionado ninguna.
            label_status("Por favor, seleccione una tarjeta a asociar."
                , true, "", false);
            return false;
        }

        private bool espaciosRellenados()
        {
            if (!String.IsNullOrEmpty(TextBox_contraseniaNueva.Text) &&
                !String.IsNullOrEmpty(TextBox_contraseniaConfirmar.Text))
            {
                return true;
            }
            label_status("Por favor, rellene todos los espacios", true, "", false);
            return false;
        }
        #endregion
    }
}