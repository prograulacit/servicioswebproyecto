using BLL.Logica;
using BLL.Objeto;
using System;

namespace Web_Application.Paginas.Compartido
{
    public partial class MasterPage_Backend : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Memoria.sesionDeAdmin)
            {
                if (Memoria.sesionAdminDatos.nombreUsuario != null &&
                    !string.IsNullOrEmpty(Memoria.sesionAdminDatos.nombreUsuario))
                {
                    Label_admin_nombreUsuario.Text = 
                        Memoria.sesionAdminDatos.nombreUsuario;
                }
            }
        }

        protected void Button_cerrar_sesion_Click(object sender, EventArgs e)
        {
            
        }

        protected void LinkButton_cerrar_sesion_Click(object sender, EventArgs e)
        {
            if (Memoria.sesionDeAdmin)
            {
                Bitacora b = new Bitacora();
                b.guardarBitacora_interfazDeUsuario("Cierre de sesion"
                    , "Admin a cerrado su sesion"
                    , $"El administrador {Memoria.sesionAdminDatos.nombreUsuario} a salido del " +
                    $"sistema.");

                Admin admin = new Admin();

                // Metodo que deslogea al admin del sistema.
                admin.deslogeo();

                // Envia al usuario nuevamente al lobby.
                Response.Redirect("~/Paginas/Compartido/index.aspx");
            }
            else
            {
                Response.Redirect("~/Paginas/Compartido/index.aspx");
            }
        }
    }
}