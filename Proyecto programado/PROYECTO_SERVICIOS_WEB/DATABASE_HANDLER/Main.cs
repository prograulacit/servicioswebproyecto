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
                tareas.crear_usuario();
                Console.WriteLine("Secuencia -> Pulsar boton -> Crear Registros -> Terminado");
                MessageBox.Show("Secuencia de datos ejecutada con exito!!");
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR! Ha habído un error en la secuencia de instrucciones\n" +
                    "Por favor, revise la conexión a la base de datos\n" +
                    "Si el problema persiste, consulte con el administrador.");
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
    }
}
