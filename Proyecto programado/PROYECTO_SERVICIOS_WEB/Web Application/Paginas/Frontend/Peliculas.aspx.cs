using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Logica;

namespace Web_Application.Paginas.Frontend
{
    public partial class Peliculas : System.Web.UI.Page
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