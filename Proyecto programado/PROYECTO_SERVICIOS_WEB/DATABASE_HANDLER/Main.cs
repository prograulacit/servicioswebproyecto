using System;
using System.Windows.Forms;

namespace DATABASE_HANDLER
{
    public partial class Main : Form
    {
        Secuencias secuencias = new Secuencias();

        public Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Boton de crear registros iniciales.
        /// </summary>
        private void button_crear_registros_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("Secuencia -> Pulsar boton -> Crear Registros -> Iniciado");
                secuencias.crearAdmin_maestro();
                secuencias.crearAdmin_seguridadMantenimientoConsultas();
                secuencias.crearRegistros_consecutivo();
                secuencias.crear_parametros();
                secuencias.crearUsuarios();
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
    }
}
