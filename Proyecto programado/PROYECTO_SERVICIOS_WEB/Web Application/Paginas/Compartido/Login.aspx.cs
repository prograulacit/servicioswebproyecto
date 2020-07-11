using System;

namespace Web_Application.Paginas.Compartido
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void button_submit_login_Click(object sender, EventArgs e)
        {
            string nombre_de_usuario = textbox_nombre_usuario.Text;
            string contrasenia = textbox_contrasenia.Text;

            //List<admin> lista_admins = 
        }
    }
}