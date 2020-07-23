using BLL.Logica;
using System;

namespace Web_Application.Paginas.Backend
{
    public partial class generosMusica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool adminMaestro = Memoria.sesionAdminDatos.adminMaestro;
            bool adminMantenimiento = Memoria.sesionAdminDatos.adminMantenimiento;

            if (!adminMaestro && !adminMantenimiento)
            {
                Response.Redirect("~/Paginas/Backend/Index.aspx");
            }
        }
    }
}