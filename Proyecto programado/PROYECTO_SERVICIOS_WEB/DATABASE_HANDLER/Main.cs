using System;
using System.Windows.Forms;

namespace DATABASE_HANDLER
{
    public partial class Main : Form
    {
        Tareas tareas = new Tareas();

        public Main()
        {
            InitializeComponent();
        }

        private void button_crear_registros_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("Secuencia -> Pulsar boton -> Crear Registros -> Iniciado");
                tareas.crear_admin_maestro();
                createAdmin_datosQuemados();
                tareas.crear_registros_de_consecutivos();
                tareas.crear_parametros();
                crear_usuarios_datos_quemados();
                Console.WriteLine("Secuencia -> Pulsar boton -> Crear Registros -> Terminado");
                MessageBox.Show("Registros creados con exito!");
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR! Ha habído un error en la secuencia de instrucciones\n" +
                    "Por favor, revise la conexión a la base de datos\n" +
                    "Si el problema persiste, consulte con el administrador.\n" +
                    "Consulte la consola para mas detalles");
            }
        }

        // Crea los admins de seguridad, mantenimiento y consultas.
        private void createAdmin_datosQuemados()
        {
            // Crear admin de seguridad.
            tareas.crear_admin("adm2"
                , "adminSeguridad"
                , "admin"
                , "adminSeguridad@e-shop.com"
                , "Respuesta de pregunta de seguridad:respuesta"
                , "respuesta"
                , "false"
                , "true"
                , "false"
                , "false");
            // Crear admin de mantenimiento.
            tareas.crear_admin("adm3"
                , "adminMantenimiento"
                , "admin"
                , "adminMantenimiento@e-shop.com"
                , "Respuesta de pregunta de seguridad:respuesta"
                , "respuesta"
                , "false"
                , "false"
                , "true"
                , "false");
            // Crear admin de consultas.
            tareas.crear_admin("adm4"
                , "adminConsultas"
                , "admin"
                , "adminConsultas@e-shop.com"
                , "Respuesta de pregunta de seguridad:respuesta"
                , "respuesta"
                , "false"
                , "false"
                , "false"
                , "true");
        }

        private void button_crear_solo_admins_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("Sencuencia -> Crear solo admins iniciada.");
                tareas.crear_admin_maestro();
                createAdmin_datosQuemados();
                Console.WriteLine("Sencuencia -> Crear solo admins terminada. OK");
                MessageBox.Show("Secuencia crear solo admins correcta!!");
            }
            catch (Exception)
            {
                Console.WriteLine("Sencuencia -> Crear solo admins terminada. ERROR");
                MessageBox.Show("ERROR! Ha habído un error en la secuencia de instrucciones\n" +
                    "Por favor, revise la conexión a la base de datos\n" +
                    "Si el problema persiste, consulte con el administrador.\n" +
                    "Consulte la consola para mas detalles");
                throw;
            }
        }

        private void crear_usuarios_datos_quemados()
        {
            tareas.crear_usuario("juanid","Juan","Mora","Tenorio","juantenorio@e-corp.usa","user","password");
            tareas.crear_usuario("cameronid", "Cameron", "Hidalgo", "Tenorio", "cameronhidalgo@e-corp.usa", "cameron", "password");
            tareas.crear_usuario("elliotid", "Elliot", "Alderson", "Seppion", "elliotalderson@e-corp.usa", "elliot", "password");
            tareas.crear_usuario("doloresid", "Dolores", "Haze", "Moggly", "doloreshaze@e-corp.usa", "dolores", "password");
        }

        private void button_crear_solo_usuarios_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("Sencuencia -> Crear solo admins iniciada.");
                crear_usuarios_datos_quemados();
                Console.WriteLine("Sencuencia -> Crear solo admins terminada. OK");
                MessageBox.Show("Secuencia crear solo usuarios correcta!!");
            }
            catch (Exception)
            {
                Console.WriteLine("Sencuencia -> Crear solo admins terminada. ERROR");
                MessageBox.Show("ERROR! Ha habído un error en la secuencia de instrucciones\n" +
                    "Por favor, revise la conexión a la base de datos\n" +
                    "Si el problema persiste, consulte con el administrador.\n" +
                    "Consulte la consola para mas detalles");
                throw;
            }
        }
    }
}
