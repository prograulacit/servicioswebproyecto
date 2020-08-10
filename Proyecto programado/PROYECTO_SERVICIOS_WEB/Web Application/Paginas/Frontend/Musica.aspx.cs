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
            // Se elimina el producto que se iba a comprar de la memoria.
            Memoria.productoAComprar = new BLL.Objeto.ProductoCompra();
        }
    }
}