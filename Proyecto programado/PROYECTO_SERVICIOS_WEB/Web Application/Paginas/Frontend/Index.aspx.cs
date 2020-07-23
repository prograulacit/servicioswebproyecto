using BLL.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Application.Paginas.Frontend
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Memoria.sesionDeUsuario)
            {
                // Envia de vuelta al usuario al index si no hay nadie logeado
                Response.Redirect("~/Paginas/Compartido/index.aspx");
            }
        }
    }
}