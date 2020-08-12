using BLL.Logica;
using BLL.Objeto;
using System;

namespace Web_Application.Paginas.Compartido
{
    public partial class MasterPage_Frontend : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Memoria.sesionSocial)
            {
                menu_ajustes_cuenta.Visible = false;
            } else
            {
                menu_ajustes_cuenta.Visible = true;
            }
        }

        protected void LinkButton_cerrar_sesion_Click(object sender, EventArgs e)
        {
            if (Memoria.sesionDeUsuario)
            {
                Usuario usuario = new Usuario();

                // Metodo que deslogea al usuario del sistema.
                usuario.deslogeo();

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