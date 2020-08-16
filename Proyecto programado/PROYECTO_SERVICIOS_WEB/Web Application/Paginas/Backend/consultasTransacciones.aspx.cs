using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Logica;

namespace Web_Application.Paginas.Backend
{
    public partial class consultasTransacciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Memoria.sesionAdminDatos != null)
            {
                bool adminMaestro = Memoria.sesionAdminDatos.adminMaestro;
                bool adminConsultas = Memoria.sesionAdminDatos.adminConsultas;

                if (!adminMaestro && !adminConsultas)
                {
                    Response.Redirect("~/Paginas/Backend/Index.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Paginas/Backend/Index.aspx");
            }
        }
    }
}