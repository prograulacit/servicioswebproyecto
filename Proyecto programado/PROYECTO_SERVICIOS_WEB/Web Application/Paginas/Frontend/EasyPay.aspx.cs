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
    public partial class EasyPay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Memoria.sesionDeUsuario)
            {
                //Response.Redirect("~/Paginas/Compartido/index.aspx");
            }
            // Los dropdowns se rellenan solo la primera vez que la pagina
            // ha sido cargada.
            if (!Page.IsPostBack)
            {
                label_status("", false, "", false);
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

        protected void Button_crearCuentaEasyPay_Click(object sender, EventArgs e)
        {
            //if (espaciosRellenados() &&
            //    tarjetaSeleccionada() &&
            //    contraseniasCoinciden())
            //{
            //    guardarCuentaEasyPay();
            //}
        }

        private void guardarCuentaEasyPay()
        {
            label_status("",false,"Cuenta guardada con exito.",true);
        }
        #region Validaciones
        private bool contraseniasCoinciden()
        {
            throw new NotImplementedException();
        }

        private bool tarjetaSeleccionada()
        {
            // validar si existe revisando las tarjetas
            // guardadas en la base de datos.
            throw new NotImplementedException();
        }

        private bool espaciosRellenados()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}