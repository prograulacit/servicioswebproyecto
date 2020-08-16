using BLL.Logica;
using System;

namespace Web_Application.Paginas.Backend
{
    public partial class categoriasLibro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Memoria.sesionAdminDatos != null)
            {
                bool adminMaestro = Memoria.sesionAdminDatos.adminMaestro;
                bool adminMantenimiento = Memoria.sesionAdminDatos.adminMantenimiento;

                if (!adminMaestro && !adminMantenimiento)
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