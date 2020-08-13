using System;
using BLL.Logica;

namespace Web_Application.Paginas.Frontend
{
    public partial class Musica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Memoria.sesionDeUsuario)
            {
                Response.Redirect("~/Paginas/Compartido/index.aspx");
            }
            // Se elimina de la memoria producto y método de pago.
            Memoria.productoAComprar = new BLL.Objeto.ProductoCompra();
            Memoria.compraMetodoDePago = new BLL.Objeto.CompraMetodoDePago();
        }
    }
}