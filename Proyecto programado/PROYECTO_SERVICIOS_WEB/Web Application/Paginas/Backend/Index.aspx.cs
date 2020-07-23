using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Objeto;
using BLL.Logica;

namespace Web_Application.Paginas.Backend
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Este código se ejecuta cada vez que se carga ésta página. Vamos a verificar
            // aquí que un administrador este logeado siempre en todas las páginas.
            // Si no es sesión de admin, el usuario es enviado de vuelta a el index.
            if (!Memoria.sesionDeAdmin)
            {
                Response.Redirect("~/Paginas/Compartido/index.aspx");
            }
        }

        protected void Button_deslogeo_prueba_Click(object sender, EventArgs e)
        {
            
        }

        protected void Button_cerrar_sesion_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();

            // Metodo que deslogea al admin del sistema.
            admin.deslogeo();

            Bitacora b = new Bitacora();
            b.guardarBitacora_interfazDeUsuario("Cierre de sesion"
                , "Admin a cerrado su sesion"
                , $"El administrador {Memoria.sesionAdminDatos.nombreUsuario} a salido del " +
                $"sistema.");

            // Envia al usuario nuevamente al lobby.
            Response.Redirect("~/Paginas/Compartido/index.aspx");
        }
    }
}
