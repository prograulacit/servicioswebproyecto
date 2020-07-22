using BLL.Logica;
using BLL.Objeto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Application.Paginas.Backend
{
    public partial class editarAdministradores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool adminMaestro = Memoria.sesionAdminDatos.adminMaestro;
            bool adminSeguridad = Memoria.sesionAdminDatos.adminSeguridad;

            if (!adminMaestro && !adminSeguridad)
            {
                Response.Redirect("~/Paginas/Backend/Index.aspx");
            }
        }

        private void cargarGrid_admins()
        {
           
        }
    }
}