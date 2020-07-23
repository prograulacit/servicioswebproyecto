using System;
using System.Collections.Generic;
using BLL.Logica;
using BLL.Objeto;

namespace Web_Application.Paginas.Backend
{
    public partial class bitacoraErroresTransaccionesDescargas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool adminMaestro = Memoria.sesionAdminDatos.adminMaestro;
            bool adminConsultas = Memoria.sesionAdminDatos.adminConsultas;

            if (!adminMaestro && !adminConsultas)
            {
                Response.Redirect("~/Paginas/Backend/Index.aspx");
            }
        }
    }
}