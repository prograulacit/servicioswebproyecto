using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Logica;
using BLL.Objeto;

namespace Web_Application.Paginas.Frontend
{
    public partial class tarjetas : System.Web.UI.Page
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
                rellenarDropdowns();
                label_status("", false, "", false);
            }
        }

        #region Rellenar dropdowns
        private void rellenarDropdowns()
        {
            rellenarDropdown_mesExpiracion();
            rellenarDropdown_anioExpiracion();
        }

        private void rellenarDropdown_anioExpiracion()
        {
            // Rellena el dropdown de año con la fecha actual + 80 años al futuro.
            int anioActual = Int32.Parse(DateTime.Now.Year.ToString());
            for (int i = 0; i < 80; i++)
            {
                DropDownList_anioExpiracion.Items.Add(new ListItem("" + anioActual));
                anioActual++;
            }
        }

        private void rellenarDropdown_mesExpiracion()
        {
            DropDownList_mesExpiracion.Items.Add(new ListItem("01"));
            DropDownList_mesExpiracion.Items.Add(new ListItem("02"));
            DropDownList_mesExpiracion.Items.Add(new ListItem("03"));
            DropDownList_mesExpiracion.Items.Add(new ListItem("04"));
            DropDownList_mesExpiracion.Items.Add(new ListItem("05"));
            DropDownList_mesExpiracion.Items.Add(new ListItem("06"));
            DropDownList_mesExpiracion.Items.Add(new ListItem("07"));
            DropDownList_mesExpiracion.Items.Add(new ListItem("08"));
            DropDownList_mesExpiracion.Items.Add(new ListItem("09"));
            DropDownList_mesExpiracion.Items.Add(new ListItem("10"));
            DropDownList_mesExpiracion.Items.Add(new ListItem("11"));
            DropDownList_mesExpiracion.Items.Add(new ListItem("12"));
        }
        #endregion

        protected void Button_guardarTarjeta_Click(object sender, EventArgs e)
        {
            // Se hacen todas las validaciones.
            if (todosLosEspaciosLlenos() &&
                tarjetaValida_longitud() &&
                tarjetaValida_numeros() &&
                tarjetaValida_tipo() &&
                cvvValido_longitud() &&
                cvvValido_numeros())
            {
                // Objeto tarjeta generado.
                Tarjeta tarjeta = generarTarjetaAGuardar();

                // Tarjeta se guarda en la base de datos.
                tarjeta.guardarTarjeta(tarjeta);

                // Se limpian los textbox
                TextBox_numeroTarjeta.Text = "";
                TextBox_cvv.Text = "";

                label_status("", false, "Tarjeta guardada con exito", true);
            }
        }

        #region Procesos logicos
        private Tarjeta generarTarjetaAGuardar()
        {
            return new Tarjeta(
                    Tareas.generar_nuevo_id_para_un_registro()
                    , obtenerIDdelUsuarioActual()
                    , TextBox_numeroTarjeta.Text
                    , DropDownList_mesExpiracion.SelectedItem.Value
                    , DropDownList_anioExpiracion.SelectedItem.Value
                    , TextBox_cvv.Text
                    , Tareas.generarMonto_tarjetaEasypay()
                    , generarTipoTarjeta());
        }

        /// <summary>
        /// Regresa el ID del usuario actual logeado. En caso de error de algun
        /// tipo obteniendo el dato, se regresa N/A.
        /// </summary>
        /// <returns>ID del usuario actual o N/A si no existe el ID.</returns>
        private string obtenerIDdelUsuarioActual()
        {
            if (Memoria.sesionUsuarioDatos != null)
            {
                return Memoria.sesionUsuarioDatos.id;
            }
            return "N/A";
        }

        /// <summary>
        /// Genera el tipo de tarjeta ya sea VISA o MASTERCART.
        /// Las tarjetas VISA comienzan siempre por 4.
        /// Las tarjetas MASTERCARD comienzan siempre por 5.
        /// </summary>
        /// <returns>V=VISA.MC=MASTERCARD</returns>
        private string generarTipoTarjeta()
        {
            string numero_tarjeta = TextBox_numeroTarjeta.Text;

            if (numero_tarjeta[0] == '4')
            {
                return "V";
            }
            return "MC";
        }
        #endregion

        #region Validaciones
        private bool tarjetaValida_numeros()
        {
            foreach (char c in TextBox_numeroTarjeta.Text)
            {
                if (!char.IsDigit(c))
                {
                    label_status("Tarjeta invalida: solo numeros enteros son admitidos.", true, "", false);
                    return false;
                }
            }
            return true;
        }

        private bool tarjetaValida_tipo()
        {
            string numero_tarjeta = TextBox_numeroTarjeta.Text;

            if (numero_tarjeta[0] == '4' || numero_tarjeta[0] == '5')
            {
                return true;
            }
            label_status("Tarjeta invalida: debe comenzar con numero 4 o 5", true, "", false);
            return false;
        }

        private bool tarjetaValida_longitud()
        {
            string numero_tarjeta = TextBox_numeroTarjeta.Text;

            if (numero_tarjeta.Length == 16)
            {
                return true;
            }
            label_status("Tarjeta invalida: longitud debe ser de 16 numeros.", true, "", false);
            return false;
        }

        private bool cvvValido_numeros()
        {
            foreach (char c in TextBox_cvv.Text)
            {
                if (!char.IsDigit(c))
                {
                    label_status("CVV invalido: solo numeros enteros son admitidos.", true, "", false);
                    return false;
                }
            }
            return true;
        }

        private bool cvvValido_longitud()
        {
            if (TextBox_cvv.Text.Length >= 3)
            {
                return true;
            }
            label_status("CVV invalido: la longitud debe ser de 3 a 4 numeros.", true, "", false);
            return false;
        }

        private bool todosLosEspaciosLlenos()
        {
            if (!String.IsNullOrEmpty(TextBox_numeroTarjeta.Text) &&
                !String.IsNullOrEmpty(TextBox_cvv.Text))
            {
                return true;
            }
            label_status("Por favor, rellene todos los espacios.", true, "", false);
            return false;
        }
        #endregion

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
    }
}