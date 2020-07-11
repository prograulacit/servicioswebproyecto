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
            Console.WriteLine("Secuencia -> Pulsar boton -> Crear Registros -> Iniciado");
            tareas.crear_admin_maestro();
            tareas.crear_registros_de_consecutivos();
            Console.WriteLine("Secuencia -> Pulsar boton -> Crear Registros -> Terminado");
        }
    }
}
